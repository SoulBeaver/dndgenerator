module DndGenerator.Monster

open System.Globalization
open FSharp.Data

open UnitsOfMeasure
open ExperiencePerCR

open DomainTypes
open DomainTypes.Type
open DomainTypes.Alignment

type MonsterCsvProvider = CsvProvider<"assets/monsters.csv">

let CreateMonster name cr offensiveStats creatureStats =
    let experienceValue = ExperiencePerCr.[cr]

    { name=name; cr={ rating=cr; reward=experienceValue }; offensiveStats=offensiveStats; creatureStats=creatureStats }

let parseMonster (row: CsvProvider<"assets/monsters.csv">.Row)  =
    let environmentList = row.Environment
    let tagsList = row.Tags

    let offensiveStats = { 
        ac=row.Ac; 
        hp=row.Hp; 
        initiative=row.Init 
    }

    let creatureStats = { 
        size=Size.Parse <| row.Size; 
        ``type``=Type.Parse <| row.Type; 
        alignment=Alignment.Parse <| row.Alignment; 
        tags = []; 
        environment=[] 
    }

    CreateMonster row.Name row.Cr offensiveStats creatureStats

let LoadMonstersFromCsv csv =
    use monsterCsvReader = System.IO.File.OpenText(csv)

    let monsterCsv = MonsterCsvProvider.Load(monsterCsvReader)

    monsterCsv.Rows 
    |> Seq.map parseMonster 
    |> Seq.toList