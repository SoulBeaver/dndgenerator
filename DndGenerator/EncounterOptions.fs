module DndGenerator.EncounterOptions
    
type DifficultyOption = Easy | Medium | Hard | Deadly

type EncounterOptions = {
    difficulty: DifficultyOption
    heroes: int list
}

let (|Level|_|) (str: string) =
    let mutable intValue = 0
    
    if System.Int32.TryParse(str, &intValue)
        then match intValue with
             | x when x < 0 -> None
             | x when x > 20 -> None
             | x -> Some x
        else None

let (|Difficulty|_|) (str: string) =
    match str with
    | "e" | "E" -> Some(Easy)
    | "m" | "M" -> Some(Medium)
    | "h" | "H" -> Some(Hard)
    | "d" | "D" -> Some(Deadly)
    | x -> None

let isComplete (options:EncounterOptions) =
    not <| options.heroes.IsEmpty