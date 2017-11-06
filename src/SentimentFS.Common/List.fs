namespace SentimentFS.Common

module List =
    let filterOut(filterList: string list)(list: string list) =
        list |> List.filter(fun x -> not (filterList |> List.exists(fun y -> x = y)))
