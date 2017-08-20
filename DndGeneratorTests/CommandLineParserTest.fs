namespace DndGeneratorTests

(*
module ``CommandLineParser - Parses command-line arguments`` =
    open NUnit.Framework
    open FsUnit

    open DndGenerator.EncounterOptions
    open DndGenerator.CommandLineParser

    [<Test>]
    let ``Toggle Verbose options`` () =
        let args = ["/v"]

        let options = parseCommandLine args
        let misc = options.misc

        options.parseMode |> should equal TopLevel
        misc.verbose |> should equal VerboseOutput

    [<Test>]
    let ``Successfully parses an easy encounter with one adventurer`` () =
        let args = ["/e"; "e"; "1"]

        let options = parseCommandLine args
        let generatorType = options.generatorType
        
        options.parseMode |> should equal Encounter

        match generatorType with
        | E(encounter) ->
            encounter.difficulty |> should equal DifficultyOption.Easy
            encounter.heroes |> should equal [1]
    
    [<Test>]
    let ``Successfully parses a hard encounter with four adventurers`` () =
        let args = ["/e"; "h"; "4"; "5"; "4"; "4" ]

        let options = parseCommandLine args
        let generatorType = options.generatorType
        
        options.parseMode |> should equal Encounter

        match generatorType with
        | E(encounter) ->
            encounter.difficulty |> should equal DifficultyOption.Hard
            encounter.heroes |> should equal [4; 4; 5; 4]
    
    [<Test>]
    let ``Fails to parse a medium encounter with no adventurers``  () =
        let args = ["/e"; "h"]

        let options = parseCommandLine args
        options.parseMode |> should equal Error

    [<Test>]
    let ``Missing difficulty defaults to Medium`` () =
        let args = ["/e"; "1"; "1"; "1"]

        let options = parseCommandLine args
        let generatorType = options.generatorType

        options.parseMode |> should equal Encounter

        match generatorType with
        | E(encounter) ->
            encounter.difficulty |> should equal DifficultyOption.Medium
            encounter.heroes |> should equal [1; 1; 1]
        
    [<Test>]
    let ``Too few args results in Error state`` () =
        let args = [ "/e" ]

        let options = parseCommandLine args
        options.parseMode |> should equal Error

    [<Test>]
    let ``Too many args results in Error state`` () =
        let args = [ "/e"; "e"; "1"; "/v" ]

        let options = parseCommandLine args
        options.parseMode |> should equal Error

    [<Test>]
    let ``Can mix multiple args in the correct order`` () =
        let args = [ "/v"; "/e"; "d"; "2" ]

        let options = parseCommandLine args

        let generatorType = options.generatorType
        let misc = options.misc

        options.parseMode |> should equal Encounter
        misc.verbose |> should equal VerboseOutput

        match generatorType with
        | E(encounter) ->
            encounter.difficulty |> should equal DifficultyOption.Deadly
            encounter.heroes |> should equal [2]
            *)