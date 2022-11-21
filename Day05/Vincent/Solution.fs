namespace AdventOfCode2021.Day05

open AdventOfCode2021.Common
open Microsoft.FSharp.Core
open FsToolkit.ErrorHandling
open FSharp.Core.Operators.Checked

type RangeX = RangeX of ``from``: X * step: X * ``to``: X
type RangeY = RangeY of ``from``: Y * step: Y * ``to``: Y

type LineDirection =
    | Horizontal of y: RangeX * Y
    | Vertical of x: X * RangeY
    | Diagonal of RangeX * RangeY

[<RequireQualifiedAccess>]
module Solution =

    let err e = Error e

    let private getDirection (line: Line) : Result<LineDirection, string> =
        let (pointAx, pointAy), (pointBx, pointBy) = line

        match (pointBx - pointAx), (pointBy - pointAy) with
        // | 0<x>, 0<y> -> SinglePoint |> Ok // TODO VRM remove me ?
        | xDiff, 0<y> when xDiff > 0<x> -> Horizontal(RangeX(pointAx, 1<x>, pointBx), pointAy) |> Ok // Right
        | xDiff, 0<y> when xDiff < 0<x> -> Horizontal(RangeX(pointAx, -1<x>, pointBx), pointAy) |> Ok // Left
        | 0<x>, yDiff when yDiff > 0<y> -> Vertical(pointAx, RangeY(pointAy, 1<y>, pointBy)) |> Ok // Down
        | 0<x>, yDiff when yDiff < 0<y> -> Vertical(pointAx, RangeY(pointAy, -1<y>, pointBy)) |> Ok // Up
        | xDiff, yDiff ->
            match Coordinate.evaluateX xDiff, Coordinate.evaluateY yDiff with
            | Positive x, Positive y when x = y ->
                Diagonal(RangeX(pointAx, 1<x>, pointBx), RangeY(pointAy, 1<y>, pointBy)) |> Ok // DownRight
            | Positive x, Negative y when x = y ->
                Diagonal(RangeX(pointAx, 1<x>, pointBx), RangeY(pointAy, -1<y>, pointBy)) |> Ok // UpRight
            | Negative x, Positive y when x = y ->
                Diagonal(RangeX(pointAx, -1<x>, pointBx), RangeY(pointAy, 1<y>, pointBy)) |> Ok // DownLeft
            | Negative x, Negative y when x = y ->
                Diagonal(RangeX(pointAx, -1<x>, pointBx), RangeY(pointAy, -1<y>, pointBy)) |> Ok // UpLeft
            | _ -> Error $"Invalid line direction %A{line}"

    let solve lineFilter input =
        result {
            let lines = DataParser.parse input
            let! lines = lines |> (List.traverseResultA getDirection)

            let lines = lines |> List.filter lineFilter

            let lineToPoints direction =
                match direction with
                | Horizontal(RangeX(fromX, stepX, toX), y) -> [ for x in fromX..stepX..toX -> (x, y) ]
                | Vertical(x, RangeY(fromY, stepY, toY)) -> [ for y in fromY..stepY..toY -> (x, y) ]
                | Diagonal(RangeX(fromX, stepX, toX), RangeY(fromY, stepY, toY)) ->
                    List.zip [ for x in fromX..stepX..toX -> x ] [ for y in fromY..stepY..toY -> y ]

            let map = lines |> List.map lineToPoints
            let points = map |> List.concat

            let points =
                points |> List.countBy id |> List.filter (fun (point, count) -> count > 1)

            return points.Length
        }
        |> Result.getOk

    let part1 input =
        solve
            (function
            | Diagonal _ -> false
            | _ -> true)
            input

    let part2 input = solve Fun.``true`` input
