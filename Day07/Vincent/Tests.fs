namespace AdventOfCode2021v2.Day07

open Swensen.Unquote
open NUnit.Framework
open FSharp.Data.LiteralProviders
open FSharp.Core.Operators.Checked

[<Timeout(2000)>]
module Tests =

    type sample = TextFile.data.sample
    type input = TextFile.data.input

    let [<Test>] ``Test 1.1`` () = test <@ (Solution.part1 sample.Text) = 37 @>
    let [<Test>] ``Test 1.2`` () = test <@ (Solution.part1 input.Text) = 349769 @>
    let [<Test>] ``Test 2.1`` () = test <@ (Solution.part2 sample.Text) = 168 @>
    let [<Test>] ``Test 2.2`` () = test <@ (Solution.part2 input.Text) = 99540554 @>
