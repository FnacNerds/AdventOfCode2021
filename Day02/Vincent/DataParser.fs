namespace AdventOfCode2021v2.Day02

open FParsec
open AdventOfCode2021v2.Common

type ParseResult =
    | Forward
    | Down
    | Up

[<RequireQualifiedAccess>]
module DataParser =

    let private parseDirection =
        ((pstring "forward") >>% Forward)
        <|> (pstring "down" >>% Down)
        <|> (pstring "up" >>% Up)

    let private parseLine = parseDirection .>>. (pchar ' ' >>. pint64)
    let private parseLines = (sepBy1 parseLine newline)

    let parse = run (parseLines .>> eof) >> FParsecResult.unwrap
