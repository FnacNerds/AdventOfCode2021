namespace AdventOfCode2021v2.Day05

open FParsec
open AdventOfCode2021v2.Common.FParsecResult
open FSharp.Core.Operators.Checked

[<Measure>]
type x

[<Measure>]
type y

type X = int<x>
type Y = int<y>

type Coordinate = X * Y

type Evaluation =
    | Positive of int
    | Negative of int
    | Zero

module Coordinate =
    let x (v: int) = v * 1<x>

    let y (v: int) = v * 1<y>

    let private evaluate i =
        if i > 0 then Positive i
        elif i < 0 then Negative(-i)
        else Zero

    let evaluateX (x: X) = evaluate (x / 1<x>)
    let evaluateY (y: Y) = evaluate (y / 1<y>)

type Line = Coordinate * Coordinate

[<RequireQualifiedAccess>]
module DataParser =

    let parseCoordinate =
        (((pint32 |>> Coordinate.x) .>> pchar ',') .>>. (pint32 |>> Coordinate.y))
        |>> Coordinate

    let parseLine =
        ((parseCoordinate .>> skipString " -> ") .>>. parseCoordinate) |>> Line

    let parseContents = sepBy1 parseLine newline

    let parse = (run (parseContents .>> eof)) >> unwrap
