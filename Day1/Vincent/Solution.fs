namespace AdventOfCode2021v2.Day01

module Solution =

    let solve = Seq.pairwise >> Seq.where (fun (x, y) -> y > x) >> Seq.length

    let part1 input = input |> DataParser.parse |> solve

    let part2 input =
        input |> DataParser.parse |> Seq.windowed 3 |> Seq.map Seq.sum |> solve
