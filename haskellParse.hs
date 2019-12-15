module Main where

import Text.ParserCombinators.ReadP hiding (get)
import Text.Read hiding ((<++), get)
import Data.Char
import Data.List
import qualified Data.Set as Set
import Control.Applicative hiding (optional)
import Control.Monad.State
import Data.Functor
import Data.Functor.Identity
import System.IO

data Action = Enter String | Exit String

data StoryLine = StoryLine {getID :: Int,
                  getSpeaker :: String,
                  getLine :: String,
                  getNexts :: [Int],
                  isChoice :: Bool,
                  getArtNum :: Int}
               | StoryEvent {getID :: Int,
                  getActions :: [Action],
                  getNext :: Int}

instance Show StoryLine where
  show (StoryLine id name line nexts isChoice artNum) =
    " line" ++ show id ++ " = new StoryLine ("
            ++ show id ++ ", "
            ++ show name ++ ", "
            ++ show line ++ ", "
            ++ "new int[] "
            ++ myShowList (map show nexts) ++ ", "
            ++ myShow isChoice ++ ", "
            ++ show artNum
                  ++ ");"
  show (StoryEvent id actions next) =
    " line" ++ show id ++ " = new StoryEvent ("
            ++ show id ++ ", "
            ++ "new Tuple<StoryEvent.Action, string>[] "
            ++ myShowList (map showAction actions) ++ ", "
            ++ show next
                  ++ ");"

showAction (Enter s) = "new Tuple<StoryEvent.Action, String>(StoryEvent.Action.Enter, \"" ++ s ++ "\")"
showAction (Exit s) = "new Tuple<StoryEvent.Action, String>(StoryEvent.Action.Exit, \"" ++ s ++ "\")"

addToDict :: StoryLine -> String
addToDict line = "        all" ++ lineType line ++ "s.Add(" ++ id ++ ", line" ++ id ++ ");" where
  id = show . getID $ line

reverseList :: [a] -> [a]
reverseList [] = []
reverseList (a:as) = reverseList as ++ [a]

showAllLines :: [StoryLine] -> String
showAllLines = unlines . map (\line -> "    public static Story" ++ lineType line ++ " " ++ (show line))

lineType :: StoryLine -> String
lineType StoryLine {} = "Line"
lineType StoryEvent {} = "Event"

myShow :: Bool -> String
myShow b
  | b = "true"
  | otherwise = "false"

myShowList :: [String] -> String
myShowList as = "{" ++ intercalate "," as ++ "}"

parseStory :: ReadP StoryLine
parseStory =
  (\num _ name _ line connects artNum ->
    StoryLine num name line (read <$> connects) ((>1) . length $ connects) artNum) <$>
  readInt           <*>
  string ". "       <*>
  munch1 (/= ':')   <*>
  string ": "       <*>
  munch1 (/= '{')   <*>
  parseList isDigit <*>
  option 0 (char ' ' *> readInt)

parseEvent :: ReadP StoryLine
parseEvent =
  (\num _ enters exits next ->
    StoryEvent num (fmap Enter enters ++ fmap Exit exits) next) <$>
  readInt       <*>
  string "."    <*>
  (option [] $
    string " Enter: " *> parseList isAlpha) <*>
  (option [] $
    string " Exit: " *> parseList isAlpha) <*>
  (char ' ' *> readInt)

readInt = read <$> munch1 isDigit
parseList elements =  (optional $ char '{') *>
                        ((munch elements) `sepBy` (string ", "))
                      <* (optional $ char '}')
runParser = readP_to_S

instance Read StoryLine where
  readsPrec _ = runParser $ parseEvent <++ parseStory

csHeader :: String
csHeader =
  "using System.Collections.Generic;" ++ "\n" ++
  "using System;" ++ "\n" ++
  "public class StoryLine" ++ "\n" ++
  "{" ++ "\n" ++
  "    public int ID;" ++ "\n" ++
  "    public string Name;" ++ "\n" ++
  "    public string Line;" ++ "\n" ++
  "    public int[] Connects;" ++ "\n" ++
  "    public bool IsChoice;" ++ "\n" ++
  "    public int ArtNum;" ++ "\n" ++
  "" ++ "\n" ++
 "\n" ++
  "" ++ "\n" ++
  "    public StoryLine (int id, string name, string line, int[] connects, bool isChoice, int artNum) " ++ "\n" ++
  "    {" ++ "\n" ++
  "        ID = id;" ++ "\n" ++
  "        Name = name;" ++ "\n" ++
  "        Line = line;" ++ "\n" ++
  "        Connects = connects;" ++ "\n" ++
  "        IsChoice = isChoice;" ++ "\n" ++
  "        ArtNum = artNum;" ++ "\n" ++
  "    }" ++ "\n" ++
  "}" ++ "\n" ++
  "" ++ "\n" ++
  "public class StoryEvent" ++ "\n" ++
  "{" ++ "\n" ++
  "    public enum Action" ++ "\n" ++
  "    {" ++ "\n" ++
  "        Enter," ++ "\n" ++
  "        Exit" ++ "\n" ++
  "    }" ++ "\n" ++
  "" ++ "\n" ++
  "    public int ID;" ++ "\n" ++
  "    public Tuple<Action, string>[] Actions;" ++ "\n" ++
  "    public int Connect;" ++ "\n" ++
  "" ++ "\n" ++
  "    public StoryEvent (int id, Tuple<Action, string>[] actions, int connect)" ++ "\n" ++
  "    {" ++ "\n" ++
  "        ID = id;" ++ "\n" ++
  "        Actions = actions;" ++ "\n" ++
  "        Connect = connect;" ++ "\n" ++
  "    }" ++ "\n" ++
  "}" ++ "\n\n" ++
  "public class Story" ++ "\n" ++
  "{" ++ "\n" ++
  "    public static Dictionary<int, StoryLine> allLines = new Dictionary<int, StoryLine>();" ++ "\n" ++
  "    public static Dictionary<int, StoryEvent> allEvents = new Dictionary<int, StoryEvent>();" ++
  "\n\n"

-- listOfNames :: [StoryLine] -> String
listOfNames = map show . Set.toList . nameSet where
  nameSet = foldr (Set.insert . getSpeakerMaybe) Set.empty
  getSpeakerMaybe StoryEvent {} = "Dawn"
  getSpeakerMaybe storyLine = getSpeaker storyLine

listOfStories :: String -> [StoryLine]
listOfStories = (map readLines) . killEmptyLines . lines . sanitize where
  killEmptyLines = filter (/= "\r")

buildList :: [StoryLine] -> String
buildList = unlines . map addToDict

sanitize :: String -> String
sanitize = filterReplace '’' "'" . filterReplace '…' "..."

filterReplace :: Char -> String -> String -> String
filterReplace _ _ [] = []
filterReplace bad good (a:rest)
  | a == bad = good ++ filterReplace bad good rest
  | otherwise = a : filterReplace bad good rest

readLines :: String -> StoryLine
readLines line = handle . readMaybe $ line where
  handle (Just a) = a
  handle Nothing = error $ "parse error on line: " ++ line


buildfullString :: [StoryLine] -> String
buildfullString myLines = csHeader ++
                          "    public static string[] allNames = " ++ myShowList (listOfNames myLines) ++ ";\n" ++
                          showAllLines myLines ++
                          "    public static void initStory() {\n" ++
                          (buildList $ myLines) ++
                          "    }\n}"

type Scene = State [String]

enter :: String -> Scene ()
enter person = do
  people <- get
  case person `elem` people of
    True -> error $ person ++ " is already in the scene"
    False -> case length people < 4 of
      False -> error "too many people in the scene"
      True -> put $ person:people

exit :: String -> Scene ()
exit person = do
  people <- get
  case person `elem` people of
    True -> put $ delete person people
    False -> error $ person ++ " can't exit since they aren't in the scene"

checkContinuity :: [StoryLine] -> [String]
checkContinuity lines = runIdentity $ execStateT (checkLines lines) [] where
  checkLines lines = sequence_ (allActions lines)
  allActions = concat . map (processActions)
  processActions event@(StoryEvent {}) = map actionToState (getActions event)
  processActions StoryLine {} = []
  actionToState (Enter person) = enter person
  actionToState (Exit person) = exit person

main :: IO ()
main = do
  allLines <- getContents
  let list = listOfStories allLines
  let leftInScene = checkContinuity list
  putStr $ buildfullString list
  hPutStrLn stderr $ "Left in scene: " ++ (unwords leftInScene)
