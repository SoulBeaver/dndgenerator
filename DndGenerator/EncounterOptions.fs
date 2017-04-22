module DndGenerator.EncounterOptions

type DifficultyOption = Easy = 0 | Medium = 1 | Hard = 2 | Deadly = 3

type EncounterOptions = {
    difficulty: DifficultyOption
    heroes: int list
}

let (|Level|_|) (str: string) =
    let mutable intValue = 0
    
    if System.Int32.TryParse(str, &intValue)
        then match intValue with
             | x when x < 1 -> None
             | x when x > 20 -> None
             | x -> Some x
        else None

let (|Difficulty|_|) (str: string) =
    match str with
    | "e" | "E" -> Some(DifficultyOption.Easy)
    | "m" | "M" -> Some(DifficultyOption.Medium)
    | "h" | "H" -> Some(DifficultyOption.Hard)
    | "d" | "D" -> Some(DifficultyOption.Deadly)
    | x -> None

let isComplete (options:EncounterOptions) =
    not <| options.heroes.IsEmpty