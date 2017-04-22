module DndGenerator.CommandLineParser

open DndGenerator.EncounterOptions

type VerboseOption = VerboseOutput | TerseOutput

type MiscOptions = {
    verbose: VerboseOption
}

type GeneratorType =
    | E of EncounterOptions
    | Unknown

type ParseMode = TopLevel | Encounter | Plot | Dungeon | Settlement | Error

type CommandLineOptions = {
    misc: MiscOptions
    parseMode: ParseMode
    generatorType: GeneratorType
}

let parseTopLevel arg miscSoFar =
    match arg with
    | "/v" ->
        let newMiscSoFar = { miscSoFar with verbose = VerboseOutput }
        { misc = newMiscSoFar; parseMode = TopLevel; generatorType = Unknown }

    | "/e" -> 
        { misc = miscSoFar; parseMode = Encounter; generatorType = E { difficulty = DifficultyOption.Medium; heroes = [] } }
    
    | x ->
        { misc = miscSoFar; parseMode = Error; generatorType = Unknown }

let parseEncounter arg miscSoFar encounterGenerator =
    match arg with
    | Level x ->
        let builder' = { encounterGenerator with heroes = x :: encounterGenerator.heroes }
        { misc = miscSoFar; parseMode = Encounter; generatorType = E builder' }

    | Difficulty x ->
        let builder' = { encounterGenerator with difficulty = x }
        { misc = miscSoFar; parseMode = Encounter; generatorType = E builder' }
    
    | _ -> 
        { misc = miscSoFar; parseMode = Error; generatorType = E encounterGenerator }

let foldFunction state element =
    match state with
    | { misc = m; parseMode = TopLevel } ->
        parseTopLevel element m

    | { misc = m; parseMode = Encounter; generatorType = E(g) } ->
        parseEncounter element m g
    
    | { parseMode = Error } ->
        state

    | { misc = m; parseMode = p; generatorType = g } -> 
        printfn "Unexpected constellation of %A %A %A" m p g
        state

let disableIfIncomplete commandLineOptions =
    match commandLineOptions.parseMode with
    | Error ->
        commandLineOptions

    | _ ->
        match commandLineOptions.generatorType with
        | E(encounter) when isComplete encounter ->
            commandLineOptions
        
        | Unknown -> commandLineOptions

        | _ -> { commandLineOptions with parseMode = Error }

let parseCommandLine args =
    let defaultOptions = { 
        verbose = TerseOutput
    }

    let initialFoldState =
        { misc = defaultOptions; parseMode = TopLevel; generatorType = Unknown }
    
    let finalFoldState = args |> List.fold foldFunction initialFoldState
    
    disableIfIncomplete finalFoldState