module MonsterTest

module ``Monster - Functionality for loading and creating a Monster`` =
    open NUnit.Framework
    open FsUnit

    open DndGenerator.DomainTypes
    open DndGenerator.Monster
    
    [<Test>]
    let ``Creating a CR 1 Orc with no other stats`` () =
        let orc = CreateMonsterBase "Orc Eye of Gruumsh" "1"

        orc.name |> should equal "Orc Eye of Gruumsh"
        orc.cr |> should equal { rating="1"; reward=200 }
    
    [<Test>]
    let ``Creating a CR 1 Orc with cool stats`` () =
        let orc = CreateMonster "Orc Eye of Gruumsh" "1" { ac=14; hp=114; initiative=2 } { size=Medium; ``type``=Humanoid; alignment=ChaoticEvil; tags=[]; environment=[] }

        orc.name |> should equal "Orc Eye of Gruumsh"
        orc.cr |> should equal { rating="1"; reward=200 }
        
        orc.offensiveStats
        |> Option.get 
        |> should equal { ac=14; hp=114; initiative=2 }

        orc.creatureStats
        |> Option.get
        |> should equal { size=Medium; ``type``=Humanoid; alignment=ChaoticEvil; tags=[]; environment=[] }
