module EncounterGeneratorTest

module ``CommandLineParser - Parses command-line arguments`` =
    open NUnit.Framework
    open FsUnit

    open DndGenerator.EncounterOptions
    open DndGenerator.EncounterGenerator

    [<Test>]
    let ``A party of four level-one adventurers has an easy party xp threshold of 100`` () =
        let partyXpThreshold = calculatePartyXpThreshold DifficultyOption.Easy [1; 1; 1; 1]

        partyXpThreshold |> should equal 100

    [<Test>]
    let ``A party of three 3rd-level characters and one 2nd-level character has a deadly party xp threshold of 1400`` () =
        let partyXpThreshold = calculatePartyXpThreshold DifficultyOption.Deadly [3; 3; 3; 2]

        partyXpThreshold |> should equal 1400