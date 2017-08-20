module Extensions

[<AutoOpen>]
module Option =
    let fromTuple (boolean:bool,value:'a) =
        if boolean then
            Some value
        else
            None