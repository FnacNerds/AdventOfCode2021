﻿namespace AdventOfCode2021v2.Common

[<RequireQualifiedAccess>]
module Seq =
    let countWhere (predicate: 'T -> bool) (seq: 'T seq) =
        seq
        |> Seq.filter predicate
        |> Seq.length