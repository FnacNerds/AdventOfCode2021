namespace AdventOfCode2021v2.Common

[<RequireQualifiedAccess>]
module Array =
    let mapTuple f = Array.map (fun a -> (a, f a))
