namespace AdventOfCode2021.Day04

open FParsec
open AdventOfCode2021.Common.FParsecResult

type DrawnNumber =
    | DrawnNumber of int

    static member Value =
        function
        | DrawnNumber v -> v

type BingoCard = BingoCard of DrawnNumber array array

type Bingo = {
    DrawnNumbers: DrawnNumber list
    Grids: BingoCard list
}

[<RequireQualifiedAccess>]
module DataParser =

    let private parseFirstLine = sepBy1 pint32 (pchar ',')

    let private bingoNumberParser = (skipMany (pchar ' ')) >>. pint32

    let private parseBingoLine: Parser<int32[], unit> =
        (parray 5 bingoNumberParser) .>> (skipNewline <|> eof)

    let private parseBingoGrid = (skipNewline) >>. (parray 5 parseBingoLine)
    let private parseContents = (parseFirstLine .>> newline) .>>. (many1 parseBingoGrid)

    let private toPoco (drawnNumbers, bingoGrids) = {
        DrawnNumbers = drawnNumbers |> List.map DrawnNumber
        Grids = bingoGrids |> List.map ((Array.map (Array.map DrawnNumber)) >> BingoCard)
    }

    let parse = (run (parseContents .>> eof)) >> unwrap >> toPoco
