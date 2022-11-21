namespace AdventOfCode2021.Day02

open FSharp.Core.Operators.Checked

[<RequireQualifiedAccess>]
module Solution =

    let part1 input =

        input
        |> DataParser.parse
        |> Seq.fold
            (fun (horizontalPosition, depth) (direction, value) ->
                match direction with
                | Forward -> (horizontalPosition + value, depth)
                | Down -> (horizontalPosition, depth + value)
                | Up -> (horizontalPosition, depth - value)
            )
            (0L, 0L)
        |> (fun (h, d) -> h * d)

    let part2 input =
        input
        |> DataParser.parse
        |> Seq.toList
        |> Seq.fold
            (fun (h, d, a) (direction, value) ->
                match direction with
                | Down -> (h, d, a + value)
                | Up -> (h, d, a - value)
                | Forward -> (h + value, d + value * a, a)
            )
            (0L, 0L, 0L)
        |> (fun (h, d, _) -> h * d)
