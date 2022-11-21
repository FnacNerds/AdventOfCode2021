namespace AdventOfCode2021.Day08

open Swensen.Unquote
open NUnit.Framework
open FSharp.Data.LiteralProviders
open FSharp.Core.Operators.Checked

[<Timeout(2000)>]
module Tests =

    type sample = TextFile.data.sample
    type input = TextFile.data.input

    let [<Test>] ``Test 1.1`` () = test <@ (Solution.part1 sample.Text) = 26 @>
    let [<Test>] ``Test 1.2`` () = test <@ (Solution.part1 input.Text) = 445 @>
    let [<Test>] ``Test 2.1`` () = test <@ (Solution.part2 sample.Text) = -1 @>
    let [<Test>] ``Test 2.2`` () = test <@ (Solution.part2 input.Text) = -1 @>
