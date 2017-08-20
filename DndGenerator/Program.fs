// D&D Thing Generator
// Generates Characters
// Generates Dungeons

// Usage: dndgenerate /e [emhd] [0-9+]
//          dndgenerate /e d 4 4 5 4
// /e   Generate Encounter. Parameter can be one of
//          e - Easy
//          m - Medium
//          h - Hard
//          d - Deadly
//      As well as a list of heroes by their levels
//
// Example:  dndgenerate /e m 4 4 5 4
//      Generate a medium encounter for three level 4 and one level 5 adventurers.

module DndGenerator.Program

open System

open DndGenerator.CommandLineParser
open DndGenerator.EncounterGenerator

[<EntryPoint>]
let main argv =    
    let options = [|"/e";"e";"1";"1";"1";"1"|] |> Array.toList |> parseCommandLine

    let isVerboseRequested = options.misc.verbose = VerboseOutput

    match options with
    | { parseMode = Encounter; generatorType = E(encounterOptions) } ->
        generateEncounter encounterOptions isVerboseRequested |> ignore
    
    | { parseMode = Error } ->
        printfn "Cannot parse with args %A" argv |> ignore
    
    | _ -> 
        printfn "Currently unsupported args %A" argv |> ignore

    Console.Read()
    0 // return an integer exit code
