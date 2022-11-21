namespace AdventOfCode2021v2.Day08

open AdventOfCode2021v2.Common
open Microsoft.FSharp.Core

[<RequireQualifiedAccess>]
module Solution =

    let part1 input =
        let data = input |> DataParser.parse

        data
        |> Seq.collect Row.output
        |> Seq.countWhere (fun d ->
            match Array.length d with
            | 2 -> true
            | 3 -> true
            | 4 -> true
            | 7 -> true
            | _ -> false
        )

    let part2 input = failwith "Not implemented"
