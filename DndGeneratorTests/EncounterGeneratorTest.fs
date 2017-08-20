module EncounterGeneratorTest

module ``CommandLineParser - Parses command-line arguments`` =
    open NUnit.Framework
    open FsUnit

    open DndGenerator.EncounterOptions
    open DndGenerator.EncounterGenerator
    open DndGenerator.Monster

    [<Test>]
    let ``A party of four level-one adventurers has an easy party xp threshold of 100`` () =
        let partyXpThreshold = calculatePartyXpThreshold DifficultyOption.Easy [1; 1; 1; 1]

        partyXpThreshold |> should equal 100

    [<Test>]
    let ``A party of three 3rd-level characters and one 2nd-level character has a deadly party xp threshold of 1400`` () =
        let partyXpThreshold = calculatePartyXpThreshold DifficultyOption.Deadly [3; 3; 3; 2]

        partyXpThreshold |> should equal 1400
    
    [<Test>]
    let ``A single CR 1 monster is worth 200xp`` () =
        let encounterXpValue = calculateAdjustedXp [ (CreateMonsterBase "Test" "1") ]

        encounterXpValue |> should equal 200

    [<Test>]
    let ``A trio of CR 1 monsters is worth 1200xp`` () =
        let encounterXpValue = calculateAdjustedXp [ (CreateMonsterBase "Test" "1"); (CreateMonsterBase "Test" "1"); (CreateMonsterBase "Test" "1") ]

        encounterXpValue |> should equal 1200
    
    [<Test>]
    let ``One-hundred Tarrasques are worth 62 million xp`` () =
        let tarrasqueArmy = [ for i in 1 .. 100 -> (CreateMonsterBase "Tarrasque" "30") ]

        let encounterXpValue = calculateAdjustedXp tarrasqueArmy

        encounterXpValue |> should equal 62_000_000