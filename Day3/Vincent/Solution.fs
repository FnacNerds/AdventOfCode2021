namespace AdventOfCode2021v2.Day03

open AdventOfCode2021v2.Common
open Microsoft.FSharp.Core
open FSharp.Core.Operators.Checked

[<RequireQualifiedAccess>]
module Solution =

    let private bitListToInt =
        List.fold0 (
            function
            | v, Bit.One -> (v <<< 1) + 1
            | v, Bit.Zero -> (v <<< 1)
        )

    [<RequireQualifiedAccess>]
    type Majority =
        | OfOne
        | OfZero

    type Selector<'a> = 'a list * 'a list -> Bit * 'a list

    let part1 input =

        let data = input |> DataParser.parse

        let summarized =
            data
            |> List.transpose
            |> List.map (
                List.fold0 (
                    function
                    | s, Zero -> s - 1
                    | s, One -> s + 1
                )
            )
            |> List.map (
                function
                | v when v < 0 -> Majority.OfZero
                | v when v > 0 -> Majority.OfOne
                | _ -> failwith "Zero ? what to do ?"
            )

        let buildNumber f =
            summarized |> List.map f |> bitListToInt

        let gammaRate =
            buildNumber (
                function
                | Majority.OfOne -> Bit.One
                | Majority.OfZero -> Bit.Zero
            )

        let epsilonRate =
            buildNumber (
                function
                | Majority.OfZero -> Bit.One
                | Majority.OfOne -> Bit.Zero
            )

        gammaRate * epsilonRate

    let part2 input =
        let data = input |> DataParser.parse

        let readBits data operator =
            let rec readBits'
                (acc: Bit list)
                (zeros: Bit list list)
                (ones: Bit list list)
                (data: Bit list list)
                : Bit list =
                match data with
                | [] ->
                    let newValue, selectedList = operator (zeros, ones)
                    readBits' (newValue :: acc) [] [] selectedList
                | line :: otherLines ->
                    match line with
                    | bit :: otherBits ->
                        match bit with
                        | Zero -> readBits' acc (otherBits :: zeros) ones otherLines
                        | One -> readBits' acc zeros (otherBits :: ones) otherLines
                    | [] -> acc |> List.rev

            readBits' [] [] [] data

        let oxygenSelector: Selector<'a> =
            function
            | [], ones -> One, ones
            | zeros, [] -> Zero, zeros
            | zeros, ones when ones.Length >= zeros.Length -> Zero, zeros
            | _, ones -> One, ones

        let oxygenGeneratorRating = oxygenSelector |> readBits data |> bitListToInt

        let co2selector: Selector<'a> =
            function
            | zeros, ones when ones.Length >= zeros.Length -> One, ones
            | zeros, _ -> Zero, zeros

        let co2scrubberRating = co2selector |> readBits data |> bitListToInt

        co2scrubberRating * oxygenGeneratorRating
