module FromHTML where

import StoryParse
import Text.ParserCombinators.ReadP
import Data.Char (isDigit, isAlphaNum, isAlpha)

-- ID=1&Name=Dawn&Nexts=1005&Outfit=1&Line=Good+morning%2C+Nyx%21+&ID=2&Name=Nyx&Nexts=2001%2C2002%2C2003&Outfit=0&Line=Hi%21+<3+

removeLeadingID :: String -> String
removeLeadingID = tail . tail . tail

parsePOST :: ReadP [StoryLine]
parsePOST = sepBy1 parseLine (string "&ID=")

parseLine :: ReadP StoryLine
parseLine = (\idnum _ name _ nexts _ artnum _ line ->
            StoryLine (read idnum) name (decodePercents line)
                (read <$> nexts) (length nexts > 1) (read artnum))
    <$> munch1 isDigit
    <*> string "&Name="
    <*> munch1 isAllowedChar
    <*> string "&Nexts="
    <*> sepBy1 (munch1 isDigit) (string "%2C")
    <*> string "&Outfit="
    <*> munch1 isDigit
    <*> string "&Line="
    <*> munch1 isAllowedChar
        where
    isAllowedChar = foldr (||) False . (<$> (isAlphaNum:otherChars)) . flip ($)
    otherChars = flip (==) <$> ['%','+','.','<','>','-','*','/']


decodePercents :: String -> String
decodePercents [] = []
decodePercents ('+':rest) = ' ':decodePercents rest
decodePercents ('%':c1:c2:rest) = case lookup [c1,c2] charDict of
            Just decoded    -> decoded:decodePercents rest
            Nothing         -> '%':c1:c2:decodePercents rest
decodePercents (c:rest) = c:decodePercents rest

charDict :: [(String, Char)]
charDict = [
    ("21",'!'),("2C",','),("28",'('),("29",')'),("3F",'?'),
    ("26",'&'),("27",'\''),("3A",':'),("3B",';'),("3D",'='),
    ("2A",'*'),("23",'#'),("2B",'+'),("2F",'/'),("40",'@'),
    ("20",' '),("22",'"'),("25",'%'),("2D",'-'),("2E",'.'),
    ("3C",'<'),("3E",'>'),("5C",'\\'),("5E",'^'),("5F",'_'),
    ("60",'`'),("7B",'{'),("7C",'|'),("7D",'}'),("7E",'~'),
    ("5B",'['),("5D",']')
    ]

getLineFromPOST :: String -> [StoryLine]
getLineFromPOST = fst . last . readP_to_S parsePOST . removeLeadingID
