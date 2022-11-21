namespace AdventOfCode2021v2.Day08

open FParsec
open AdventOfCode2021v2.Common.FParsecResult

type Row =
    | Row of wiring: char array array * output: char array array

    static member mk(wiring: char list array, output: char list array) =
        Row(wiring |> Array.map Array.ofList, output |> Array.map Array.ofList)

    static member wiring(this) =
        match this with
        | Row(wiring, _) -> wiring

    static member output(this) =
        match this with
        | Row(_, output) -> output

[<RequireQualifiedAccess>]
module DataParser =

    let private possibleChars = [| 'a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g' |]

    let private parsePart count =
        parray count (opt (skipChar ' ') >>. many1 (anyOf possibleChars))

    let private parseLine =
        (((parsePart 10) .>> skipString " | ") .>>. (parsePart 4)) |>> Row.mk

    let private parseContents = sepBy1 parseLine newline

    let parse = (run (parseContents .>> eof)) >> unwrap
