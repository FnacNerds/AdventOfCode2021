namespace AdventOfCode2021.Day03

open FParsec
open AdventOfCode2021.Common.FParsecResult

type Bit =
    | Zero
    | One

[<RequireQualifiedAccess>]
module DataParser =

    let private parseLine = many ((pchar '0' >>% Zero) <|> (pchar '1' >>% One))

    let private parseLines = (sepBy1 parseLine newline)

    let parse = (run (parseLines .>> eof)) >> unwrap
