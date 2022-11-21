namespace AdventOfCode2021.Day06

open Swensen.Unquote
open NUnit.Framework
open FSharp.Data.LiteralProviders

[<Timeout(2000)>]
module Tests =

    type sample = TextFile.data.sample
    type input = TextFile.data.input

    let [<Test>] ``Test 1.1`` () = test <@ (Solution.part1 sample.Text) = 5934 @>
    let [<Test>] ``Test 1.2`` () = test <@ (Solution.part1 input.Text) = 388739 @>
    let [<Test>] ``Test 2.1`` () = test <@ (Solution.part2 sample.Text) = 26984457539L @>
    let [<Test>] ``Test 2.2`` () = test <@ (Solution.part2 input.Text) = 1741362314973L @>
