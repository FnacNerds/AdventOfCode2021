namespace AdventOfCode2021.Day06

open AdventOfCode2021.Common
open Microsoft.FSharp.Core

[<Measure>]
type day

[<RequireQualifiedAccess>]
module Solution =

    let rec private addDays days state =
        match days with
        | 0<day> -> state
        | _ ->
            addDays (days - 1<day>) [|
                state[1]
                state[2]
                state[3]
                state[4]
                state[5]
                state[6]
                state[7] + state[0]
                state[8]
                state[0]
            |]

    let solveFor days input =
        let data = input |> DataParser.parse |> List.countBy id |> Map.ofList

        [| 0..8 |]
        |> Array.map (fun i -> (Map.tryFind i data) |> Option.defaultValue 0 |> int64)
        |> (addDays days)
        |> Array.sum

    let part1 = solveFor 80<day>

    let part2 = solveFor 256<day>
