namespace DndGeneratorTests

module ``EncounterOptions - Command line arguments for building an encounter`` =
    open NUnit.Framework
    open FsUnit

    open DndGenerator.EncounterOptions

    [<Test>]
    let ``Parsing a level`` () =
        let level = "1"

        let parsed = 
            match level with
            | Level x -> x
            | _ -> -1
        
        parsed |> should equal 1

    [<Test>]
    let ``Level does not allow negative values`` () =
        let level = "-1"

        let parsed =
            match level with
            | Level x -> Some x
            | x -> None
        
        parsed |> Option.isNone |> should equal true

    [<Test>]
    let ``Level does not allow values greater than 20`` () =
        let level = "21"

        let parsed =
            match level with
            | Level x -> Some x
            | x -> None
        
        parsed |> Option.isNone |> should equal true

    [<Test>]
    let ``Parsing difficulty`` () =
        let difficulty = "e"

        let parsed = 
            match difficulty with
            | Difficulty x -> Some x
            | x -> None
        
        parsed |> Option.get |> should equal Easy

    [<Test>]
    let ``Parsing difficulty is case insensitive`` () =
        let difficulty = "E"

        let parsed =
            match difficulty with
            | Difficulty x -> Some x
            | x -> None
        
        parsed |> Option.get |> should equal Easy