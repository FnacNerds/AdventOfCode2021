namespace AdventOfCode2021.Common

[<RequireQualifiedAccess>]
module Array =
    let mapTuple f = Array.map (fun a -> (a, f a))
