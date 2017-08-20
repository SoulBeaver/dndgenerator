module Main

open Expecto

open MonsterTest

[<EntryPoint>]
let main args =
  runTestsWithArgs defaultConfig args ``Monster - Functionality for loading and creating a Monster``.tests