module MonsterTest

module ``Monster - Functionality for loading and creating a Monster`` =
    open System.IO
    
    open DndGenerator.DomainTypes
    open DndGenerator.Monster
    
    (*
    [<Test>]
    let ``Creating a CR 1 Orc with cool stats`` () =
        let orc = CreateMonster "Orc Eye of Gruumsh" "1" { ac="14"; hp=114; initiative=2 } { size=Medium; ``type``=Humanoid; alignment=ChaoticEvil; tags=[]; environment=[] }

        orc.name |> should equal "Orc Eye of Gruumsh"
        orc.cr |> should equal { rating="1"; reward=200 }
        
        orc.offensiveStats
        |> should equal { ac="14"; hp=114; initiative=2 }

        orc.creatureStats
        |> should equal { size=Medium; ``type``=Humanoid; alignment=ChaoticEvil; tags=[]; environment=[] }

    
    [<Test>]
    let ``Create a Manticore from a CSV file`` () =
        let csvFile = Path.Combine(__SOURCE_DIRECTORY__, "assets/manticore.csv")

        let manticore = LoadMonstersFromCsv csvFile |> Seq.exactlyOne

        manticore.name |> should equal "Manticore"
        manticore.cr |> should equal { rating="3"; reward=700 }

        manticore.offensiveStats
        |> should equal { ac="14"; hp=68; initiative=3 }

        manticore.creatureStats
        |> should equal { size=Large; ``type``=Monstrosity; alignment=LawfulEvil; tags=[]; environment=[] }
    
    
    [<Test>]
    let ``Create a Githyanki Knight from a CSV row`` () =
        let tokens = "54fd43f7-d101-461d-b6db-e64f095eed84,mm.githyanki-knight,Githyanki Knight,8,Medium,Humanoid,Gith,Gith,lawful evil,\"planar, swamp\",18,91,2,,,,Monster Manual: 160".Split(',')

        let githyankiKnight = assembleMonster tokens

        githyankiKnight.name |> should equal "Githyanki Knight"
        githyankiKnight.cr |> should equal { rating="8"; reward=3900 }

        githyankiKnight.offensiveStats
        |> should equal { ac="18"; hp=91; initiative=2 }

        githyankiKnight.creatureStats
        |> should equal { size=Medium; ``type``=Humanoid; alignment=LawfulEvil; tags=[]; environment=[] }
        
    [<Test>]
    let ``Create a Kraken from a TSV-token-list`` () =
        let tokens = "db248a11-5c00-433b-91e5-606ac09a3df9	mm.kraken	Kraken	23	Gargantuan	Monstrosity	Titan	chaotic evil	aquatic, coast	18	472	0	lair	legendary	Monster Manual: 197".Split('\t')

        let kraken = assembleMonster tokens

        kraken.name |> should equal "Kraken"
        kraken.cr |> should equal { rating="23"; reward=50000 }

        kraken.offensiveStats
        |> should equal { ac="18"; hp=472; initiative=0 }

        kraken.creatureStats
        |> should equal { size=Gargantuan; ``type``=Monstrosity; alignment=ChaoticEvil; tags=[]; environment=[] }
        *)