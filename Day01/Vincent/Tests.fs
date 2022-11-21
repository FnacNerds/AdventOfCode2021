namespace AdventOfCode2021v2.Day01

open Swensen.Unquote
open NUnit.Framework
open FSharp.Data.LiteralProviders

module Tests =

    type sample = TextFile.data.sample
    type input = TextFile.data.input

    let [<Test>] ``Test 1.1`` () = test <@ (Solution.part1 sample.Text) = 7 @>
    let [<Test>] ``Test 1.2`` () = test <@ (Solution.part1 input.Text) = 1709 @>
    let [<Test>] ``Test 2.1`` () = test <@ (Solution.part2 sample.Text) = 5 @>
    let [<Test>] ``Test 2.2`` () = test <@ (Solution.part2 input.Text) = 1761 @>
