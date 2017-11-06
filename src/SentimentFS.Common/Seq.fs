namespace SentimentFS.Common

module Seq =
    let filterOut(filterSeq: string seq)(list: string seq) =
        list |> Seq.filter(fun x -> not (filterSeq |> Seq.exists(fun y -> x = y)))
