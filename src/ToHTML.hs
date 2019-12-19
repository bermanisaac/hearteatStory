module Main where

import StoryParse
import Pretty

main :: IO ()
main = putStrLn "hi"


storyLineInput :: StoryLine -> HTML
storyLineInput StoryLine {getID = lineID} = do
  input "id" "int" (show lineID)
