namespace SentimentFS.Common

module Map =

    let mapValues(weight: int)(words: string list) =
        words |> List.fold(fun (acc: Map<string, int>) (key: string) ->
                                match acc.TryFind(key) with | Some x -> acc.Add(key, x + weight) | None -> acc.Add(key, weight)
                            )  Map.empty<string, int>

    /// Returns merged maps
    ///
    /// ## Parameters
    ///  - `f` - mapping function
    ///  - `map1` - Map
    ///  - `map2` - Map
    let merge<'a, 'b when 'a : comparison>(f: ('a * 'b * 'b)-> 'b)(map1: Map<'a, 'b>)(map2: Map<'a, 'b>) =
        Map.fold (fun (acc: Map<'a,'b>) key value ->
                        match acc.TryFind(key) with
                        | Some x -> acc.Add(key, f(key, value, x))
                        | None -> acc.Add(key, value)
                    ) map2 map1

     // sum of values
    let accumulateAllValues(map: Map<_, int>) =
        List.sumBy (fun (_,v) -> v) (map |> Map.toList)

    let take(tokens: _ list)(map: Map<_, _>) =
        map |> Map.filter(fun key _ -> tokens |> List.exists(fun x -> x = key))
