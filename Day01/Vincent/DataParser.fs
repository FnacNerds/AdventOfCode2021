namespace AdventOfCode2021v2.Day01

open FParsec
open AdventOfCode2021v2.Common

[<RequireQualifiedAccess>]
module DataParser =

    let private parseLines = (sepBy1 pint32 newline)
    let parse = run (parseLines .>> eof) >> FParsecResult.unwrap >> Seq.ofList
