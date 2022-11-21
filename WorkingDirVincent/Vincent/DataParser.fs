namespace AdventOfCode2021v2.{{{Project}}}

open FParsec
open AdventOfCode2021v2.Common.FParsecResult
open FSharp.Core.Operators.Checked

[<RequireQualifiedAccess>]
module DataParser =

    let parse = run pfail
