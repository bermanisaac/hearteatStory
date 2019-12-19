module Main where

import StoryParse
import Pretty

sampleLine = StoryLine 1 "Isaac" "Fuck!" [1, 1, 1] False 0

main :: IO ()
main = do
  lines <- getContents
  let lineList = map storyLineInput $ listOfStories lines
  putStrLn $ render $ htmlPage lineList


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
  newline
  string $ "Action! <br>"


htmlPage :: [HTML] -> HTML
htmlPage inputs = html $ do
                    Pretty.head $ do
                        title $ string "heart(b)eat Script Service"
                    body $ do
                        h3 $ string "Lines:"
                        postForm $ do
                            sequence_ inputs
                            string $ "<input type = \"submit\">"
