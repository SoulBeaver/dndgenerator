module MonsterTest

module ``Monster - Functionality for loading and creating a Monster`` =
    open System.IO
    
    open DndGenerator.DomainTypes
    open DndGenerator.Monster
    
    open Expecto

    let tests =
        testList "Testing a Monster" [
            test "Creating a CR 1 Orc with cool stats" {
                let orc = CreateMonster "Orc Eye of Gruumsh" "1" { ac="14"; hp=114; initiative=2 } { size=Medium; ``type``=Humanoid; alignment=ChaoticEvil; tags=[]; environment=[] }

                Expect.equal orc.name "Orc Eye of Gruumsh" "orc.name"
                Expect.equal orc.cr { rating="1"; reward=200 } "orc.cr"
                Expect.equal orc.offensiveStats { ac="14"; hp=114; initiative=2 } "orc.offensiveStats"
                Expect.equal orc.creatureStats { size=Medium; ``type``=Humanoid; alignment=ChaoticEvil; tags=[]; environment=[] } "orc.creatureStats"
            }

            test "Create a Manticore from a CSV file" {
                let csvFile = Path.Combine(__SOURCE_DIRECTORY__, "assets/manticore.csv")

                let manticore = LoadMonstersFromCsv csvFile |> Seq.exactlyOne

                Expect.equal manticore.name "Manticore" "manticore.name"
                Expect.equal manticore.cr { rating="3"; reward=700 } "manticore.cr"
                Expect.equal manticore.offensiveStats { ac="14"; hp=68; initiative=3 } "manticore.offensiveStats"
                Expect.equal manticore.creatureStats { size=Large; ``type``=Monstrosity; alignment=LawfulEvil; tags=[]; environment=[] } "manticore.creatureStats"
            }

            test "Create a Githyanki Knight from a CSV row" {
                let csvFile = Path.Combine(__SOURCE_DIRECTORY__, "assets/gith.csv")

                let gith = LoadMonstersFromCsv csvFile |> Seq.exactlyOne

                Expect.equal gith.name "Githyanki Knight" "gith.name"
                Expect.equal gith.cr { rating="8"; reward=3900 } "gith.cr"
                Expect.equal gith.offensiveStats { ac="18"; hp=91; initiative=2 } "gith.offensiveStats"
                Expect.equal gith.creatureStats { size=Medium; ``type``=Humanoid; alignment=LawfulEvil; tags=[]; environment=[] } "gith.creatureStats"
            }

            test "Create a Kraken from a TSV-token-list" {
                let csvFile = Path.Combine(__SOURCE_DIRECTORY__, "assets/kraken.csv")

                let kraken = LoadMonstersFromCsv csvFile |> Seq.exactlyOne

                Expect.equal kraken.name "Kraken" "kraken.name"
                Expect.equal kraken.cr { rating="23"; reward=50000 } "kraken.cr"
                Expect.equal kraken.offensiveStats { ac="18"; hp=472; initiative=0 } "kraken.offensiveStats"
                Expect.equal kraken.creatureStats { size=Gargantuan; ``type``=Monstrosity; alignment=ChaoticEvil; tags=[]; environment=[] } "kraken.creatureStats"
            }
        ]