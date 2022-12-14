namespace AdventOfCode2021.Day06

open FParsec
open AdventOfCode2021.Common.FParsecResult

[<RequireQualifiedAccess>]
module DataParser =

    let private parseContents = sepBy1 pint32 (pchar ',')

    let parse = (run (parseContents .>> eof)) >> unwrap
