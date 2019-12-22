module ToHTML (makePageA, makePageL) where

import StoryParse
import Pretty
import FromHTML
import System.Environment

sampleLine = StoryLine 1 "Isaac" "Fuck!" [1, 1, 1] False 0

main :: IO ()
main = do
  args <- getArgs
  case args of
    "action":_ -> interact makePageA
    _ -> interact makePageL

makePageA :: String -> String
makePageA = render . htmlPageAction . (map storyLineInput) . readPOST

makePageL :: String -> String
makePageL = render . htmlPageLine . (map storyLineInput) . readPOST

storyLineInput :: StoryLine -> HTML
storyLineInput (StoryLine id speaker line nexts _ outfit) = do
  newline
  input "number" "ID" (show id)
  input "text" "Name" speaker
  input "text" "Nexts" (filter (not . (`elem` "[]")) $ show nexts)
  input "number" "Outfit" (show outfit)
  newline
  string "<br>"
  input "text\" size = \"70" "Line" line
  newline
  string "<br> <br>"
storyLineInput (StoryEvent id actions next) = do
  input "number" "ID" (show id)
  tagArgs "select" "name = \"ActionType\"" $ do
    inlineTag "option" $ string "Enter"
    inlineTag "option" $ string "value = \"Exit\""
  input "text" "Next" (show next)
  newline
  string "<br><br>"


htmlPageLine :: [HTML] -> HTML
htmlPageLine inputs = html $ do
                    Pretty.head $ do
                        title $ string "heart(b)eat Script Service"
                    body $ do
                        h3 $ string "Lines:"
                        postForm $ do
                            sequence_ inputs
                            storyLineInput (StoryLine 0 "" "" [0] False 0)
                            newline
                            string "<br>"
                            newline
                            string $ "<input type = \"submit\" name = \"New Line\" formaction = \"saveWithLine\">"
                            newline
                            string $ "<input type = \"submit\" name = \"New Action\" formaction = \"saveWithAction\">"

htmlPageAction :: [HTML] -> HTML
htmlPageAction inputs = html $ do
                    Pretty.head $ do
                        title $ string "heart(b)eat Script Service"
                    body $ do
                        h3 $ string "Lines:"
                        postForm $ do
                            sequence_ inputs
                            storyLineInput (StoryEvent 0 [Enter ""] 0)
                            newline
                            string "<br>"
                            newline
                            string $ "<input type = \"submit\" value = \"New Line\" formaction = \"saveWithLine\">"
                            newline
                            string $ "<input type = \"submit\" value = \"New Action\" formaction = \"saveWithAction\">"
