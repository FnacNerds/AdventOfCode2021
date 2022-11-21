namespace AdventOfCode2021.Common

[<RequireQualifiedAccess>]
module Map =
    let findIn (map: Map<'Key, 'Value>) (key: 'Key) = Map.find key map
