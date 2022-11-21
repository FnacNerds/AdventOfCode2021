namespace AdventOfCode2021.Day07

open FParsec
open AdventOfCode2021.Common.FParsecResult

[<RequireQualifiedAccess>]
module DataParser =

    let parse = (run (sepBy1 pint32 (pchar ',') .>> eof)) >> unwrap
