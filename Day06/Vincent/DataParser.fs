namespace AdventOfCode2021v2.Day06

open FParsec
open AdventOfCode2021v2.Common.FParsecResult

[<RequireQualifiedAccess>]
module DataParser =

    let private parseContents = sepBy1 pint32 (pchar ',')

    let parse = (run (parseContents .>> eof)) >> unwrap
