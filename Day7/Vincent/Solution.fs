namespace AdventOfCode2021v2.Day07

open AdventOfCode2021v2.Common
open AdventOfCode2021v2.Common.Int
open Microsoft.FSharp.Core
open FSharp.Core.Operators.Checked

[<Measure>]
type crab

[<Measure>]
type position

[<Measure>]
type fuel

[<RequireQualifiedAccess>]
module Solution =

    let simpleMoveToPositionCost
        (crabsCount: int<crab>)
        (crabsPosition: int<position>)
        (targetCrabsPosition: int<position>)
        : int<fuel> =

        let movingCost = 1<fuel> / 1<crab> / 1<position>

        let distanceToMove = abs (crabsPosition - targetCrabsPosition)
        movingCost * distanceToMove * crabsCount

    let advancedMoveToPositionCost
        (crabsCount: int<crab>)
        (crabsPosition: int<position>)
        (targetCrabsPosition: int<position>)
        : int<fuel> =

        let distanceToMove = abs (crabsPosition - targetCrabsPosition)

        let cost: int<fuel/crab> =
            distanceToMove
            |> int
            |> Int.``sum of first n natural numbers``
            |> (*) 1<fuel / crab>

        cost * crabsCount

    let private solve costCalculator input =
        let crabsPerPosition =
            DataParser.parse input
            |> List.countBy id
            |> List.map (fun (index, count) -> (index * 1<position>, count * 1<crab>))
            |> List.sort

        let crabsPerPosition =
            List.unfold
                (fun (crabsPerPosition, position) ->
                    match crabsPerPosition with
                    | [] -> None
                    | (nextPosition, nextCrabCount) :: others when nextPosition = position ->
                        Some((nextPosition, nextCrabCount), (others, nextPosition + 1<position>))
                    | _ -> Some((position, 0<crab>), (crabsPerPosition, position + 1<position>))
                )
                (crabsPerPosition, 0<position>)

        crabsPerPosition
        |> List.map fst
        |> List.map (fun targetPosition ->
            crabsPerPosition
            |> List.map (fun (position, crabs) -> costCalculator crabs position targetPosition)
            |> List.sum
        )
        |> List.min
        |> int

    let part1 = solve simpleMoveToPositionCost

    let part2 = solve advancedMoveToPositionCost
