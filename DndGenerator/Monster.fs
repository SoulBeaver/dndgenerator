module DndGenerator.Monster

open System.Globalization

open UnitsOfMeasure
open ExperiencePerCR

open DomainTypes
open DomainTypes.Type
open DomainTypes.Alignment

let CreateMonster name cr offensiveStats creatureStats =
    let experienceValue = ExperiencePerCr.[cr]

    { name=name; cr={ rating=cr; reward=experienceValue }; offensiveStats=(Some offensiveStats); creatureStats=(Some creatureStats) }

let CreateMonsterBase name cr =
    let experienceValue = ExperiencePerCr.[cr]

    { name=name; cr={ rating=cr; reward=experienceValue }; offensiveStats=None; creatureStats=None }

let assembleMonster tokens =
    match tokens with
    | [|_;_;name;cr;(Size size);(Type ``type``);tags;_;(Alignment alignment);environment;ac;hp;init;sources|]
    | [|_;_;name;cr;(Size size);(Type ``type``);tags;_;(Alignment alignment);environment;ac;hp;init;_;sources|]
    | [|_;_;name;cr;(Size size);(Type ``type``);tags;_;(Alignment alignment);environment;ac;hp;init;_;_;sources|]
    | [|_;_;name;cr;(Size size);(Type ``type``);tags;_;(Alignment alignment);environment;ac;hp;init;_;_;_;sources|] ->
        CreateMonster name cr { ac=(int ac); hp=(int hp); initiative=(int init) } { size=size; ``type``=``type``; alignment=alignment; tags = []; environment=[] }
    | _ -> raise (System.ArgumentException "Tokens did not conform to any expected permutaytion.")

let LoadMonstersFromFile tsvFile =
    let contents = 
        System.IO.File.ReadAllLines tsvFile
        |> Seq.skip 1
        |> Seq.map (fun entry -> entry.Split('\t'))
        |> Seq.map assembleMonster
    
    contents
