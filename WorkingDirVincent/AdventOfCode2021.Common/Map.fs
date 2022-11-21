namespace AdventOfCode2021v2.Common

[<RequireQualifiedAccess>]
module Map =
    let findIn (map: Map<'Key, 'Value>) (key: 'Key) = Map.find key map
