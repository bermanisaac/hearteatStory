module Main where

import StoryParse
import System.IO

main :: IO ()
main = do
  allLines <- getContents
  let list = listOfStories allLines
  let leftInScene = checkContinuity list
  putStr $ buildFullString list
  hPutStrLn stderr $ "Left in scene: " ++ (unwords leftInScene)
