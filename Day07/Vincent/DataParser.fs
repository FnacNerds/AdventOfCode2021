namespace AdventOfCode2021v2.Day07

open FParsec
open AdventOfCode2021v2.Common.FParsecResult

[<RequireQualifiedAccess>]
module DataParser =

    let parse = (run (sepBy1 pint32 (pchar ',') .>> eof)) >> unwrap
