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

[<EntryPoint>]
let main argv =    
    let options = [|"/e";"e";"1";"1";"1";"1"|] |> Array.toList |> parseCommandLine

    printfn "%A" options

    Console.Read()
    0 // return an integer exit code
