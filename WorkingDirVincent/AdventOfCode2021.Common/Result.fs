namespace AdventOfCode2021v2.Common

[<RequireQualifiedAccess>]
module Result =
    let getOk (result: Result<'a, 'b>) =
        match result with
        | Ok x -> x
        | Error x -> failwithf "Result was an error: %A" x
