namespace SentimentFS.Common

module Func =
    open System.Collections.Generic

    let memonize f =
        let cache = Dictionary<_,_>()
        fun x ->
            match cache.TryGetValue(x) with
            | true, value -> value
            | _ ->
                let result = f x
                cache.Add(x, result)
                result
