namespace AdventOfCode2021.Day04

open AdventOfCode2021.Common
open Microsoft.FSharp.Core
open FSharp.Core.Operators.Checked

type DrawnPosition =
    | DrawnPosition of int

    member this.Value =
        match this with
        | DrawnPosition v -> v

[<RequireQualifiedAccess>]
module Solution =

    let private solve strategy (input: string) : int =
        let data = input |> DataParser.parse

        let positions =
            data.DrawnNumbers |> Seq.mapi (fun i x -> (x, DrawnPosition i)) |> Map.ofSeq

        let getPosition = (Map.findIn positions)
        let getPositions = Array.map getPosition

        let grids =
            data.Grids
            |> Seq.map (fun (BingoCard grid) ->

                let winningDrawnPosition =
                    [| grid; grid |> Array.transpose |]
                    |> Seq.concat
                    |> Seq.map (getPositions >> Seq.max)
                    |> Seq.min

                (winningDrawnPosition, grid)
            )

        let (winningPosition: DrawnPosition, grid) = grids |> strategy fst

        let winningNumber =
            List.item winningPosition.Value data.DrawnNumbers |> DrawnNumber.Value

        let sumOfNotDrawnNumbers =
            grid
            |> Array.concat
            |> Array.choose (fun n ->
                if (n |> getPosition) > winningPosition then
                    Some n
                else
                    None
            )
            |> ((Array.map DrawnNumber.Value) >> Array.sum)

        winningNumber * sumOfNotDrawnNumbers

    let part1 input = solve Seq.minBy input

    let part2 input = solve Seq.maxBy input
