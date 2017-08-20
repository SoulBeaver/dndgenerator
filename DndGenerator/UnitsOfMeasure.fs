module DndGenerator.UnitsOfMeasure

[<AutoOpen>]
module UnitsOfMeasure =
    [<Measure>]
    type ft

    [<Measure>]
    type m

    let feetPerMeter = 3.28084<ft/m>