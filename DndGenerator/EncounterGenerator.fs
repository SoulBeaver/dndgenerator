module DndGenerator.EncounterGenerator

open DomainTypes
open EncounterOptions
open Monster
open EncounterDifficultyByLevel

let calculatePartyXpThreshold difficulty heroes =
    heroes 
    |> List.map (fun levelIndex -> xpThresholdsPerLevel.[levelIndex - 1].[int difficulty]) 
    |> List.sum

let calculateAdjustedXp (monsters: Monster list) =
    let totalXp = 
        monsters
        |> List.map (fun monster -> monster.cr.reward)
        |> List.sum
    
    let groupSizeModifier = 
        match monsters.Length with
        | 0 -> 0.0
        | 1 -> 1.0
        | 2 -> 1.5
        | 3 | 4 | 5 | 6 -> 2.0
        | 7 | 8 | 9 | 10 -> 2.5
        | 11 | 12 | 13 | 14 -> 3.0
        | _ -> 4.0

    (float totalXp) * groupSizeModifier

let generateEncounter encounterOptions verbose =
    let partyXpThreshold = calculatePartyXpThreshold encounterOptions.difficulty encounterOptions.heroes
        
    if verbose then do printfn "The party's xp threshold is %i" partyXpThreshold
    
    
    ""