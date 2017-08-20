module DndGenerator.DomainTypes

open System
open System.Globalization

open Extensions

[<AutoOpen>]
module DomainTypes = 
    type CR = {
        rating: string
        reward: int
    }

    [<AutoOpen>]
    module Size =
        type T = Tiny | Small | Medium | Large | Huge | Gargantuan

        let (|Size|_|) (str: string) =
            let lowerCase = str.ToLower CultureInfo.CurrentCulture
            
            match lowerCase with
            | "tiny" -> Some Tiny
            | "small" -> Some Small
            | "medium" -> Some Medium
            | "large" -> Some Large
            | "huge" -> Some Huge
            | "gargantuan" -> Some Gargantuan
            | _ -> None

    [<AutoOpen>]
    module Type =
        type T = Aberration | Beast | Celestial | Construct | Dragon | Elemental | Fey | Fiend | Giant | Humanoid | Monstrosity | Ooze | Plant | Undead

        let (|Type|_|) (str: string) =
            let lowerCase = str.ToLower CultureInfo.CurrentCulture
    
            match lowerCase with
            | "aberration" -> Some Aberration
            | "beast" -> Some Beast
            | "celestial" -> Some Celestial
            | "construct" -> Some Construct
            | "dragon" -> Some Dragon
            | "elemental" -> Some Elemental
            | "fey" -> Some Fey
            | "fiend" -> Some Fiend
            | "giant" -> Some Giant
            | "humanoid" -> Some Humanoid
            | "monstrosity" -> Some Monstrosity
            | "ooze" -> Some Ooze
            | "plant" -> Some Plant
            | "undead" -> Some Undead
            | _ -> None

    [<AutoOpen>]
    module Alignment =
        type T = LawfulGood | LawfulNeutral | LawfulEvil | NeutralGood | Neutral | NeutralEvil | ChaoticGood | ChaoticNeutral | ChaoticEvil | Unaligned

        let (|Alignment|_|) (str: string) =
            let lowerCase = str.ToLower CultureInfo.CurrentCulture
    
            match lowerCase with
            | "lawful good" -> Some LawfulGood
            | "lawful neutral" -> Some LawfulNeutral
            | "lawful evil" -> Some LawfulEvil
            | "neutral good" -> Some NeutralGood
            | "neutral" -> Some Neutral
            | "neutral evil" -> Some NeutralEvil
            | "chaotic good" -> Some ChaoticGood
            | "chaotic neutral" -> Some ChaoticNeutral
            | "chaotic evil" -> Some ChaoticEvil
            | _ -> None

    [<AutoOpen>]
    module Environment =
        type T = Aquatic | Arctic | Cave | Coast | Desert | Dungeon | Forest | Grassland | Mountain | Planar | Ruins | Swamp | Underground | Urban
    
        let (|Environment|_|) (str: string) =
            let lowerCase = str.ToLower CultureInfo.CurrentCulture
    
            match lowerCase with
            | "aquatic" -> Some Aquatic
            | "arctic" -> Some Arctic
            | "cave" -> Some Cave
            | "coast" -> Some Coast
            | "desert" -> Some Desert
            | "dungeon" -> Some Dungeon
            | "forest" -> Some Forest
            | "grassland" -> Some Grassland
            | "mountain" -> Some Mountain
            | "planar" -> Some Planar
            | "ruins" -> Some Ruins
            | "swamp" -> Some Swamp
            | "underground" -> Some Underground
            | "urban" -> Some Urban
            | _ -> None

    type Dice = D3 | D4 | D6 | D8 | D10 | D12 | D20 | D100

    type HitDice = {
        die: Dice
        multiplier: int
        bonus: int
    }

    [<AutoOpen>]
    module AC =
        type T = AC of int

        let create success failure (i:int) =
            if i >= 0 
                then Some (AC i)
                else None
    
        let apply f (AC e) = f e

        let value e = apply id e

    type OffensiveStats = {
        ac: int
        hp: int
        initiative: int
    }

    type CreatureStats = {
        size: Size.T
        ``type``: Type.T
        tags: string list
        alignment: Alignment.T
        environment: Environment.T list
    }

    type Monster = {
        name: string
        cr: CR
    
        offensiveStats: OffensiveStats option
        creatureStats: CreatureStats option
    }