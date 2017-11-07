namespace SentimentFS.Common.Tests

module Seq =

    open Expecto
    open SentimentFS.Common

    [<Tests>]
    let tests =
        testList "Seq" [
            testList "filterOut" [
                testCase "delete when elements exist in  filter list" <| fun _ ->
                    let subject = ["A"; "B"; "C"] |> Seq.filterOut ["C"]
                    Expect.sequenceEqual subject (["A";"B"] |> List.toSeq) "should equal ['A';'B']"
                testCase "delete when elements no exist in filter list" <| fun _ ->
                    let subject = ["A"; "B"; "C"] |> Seq.filterOut ["D"]
                    Expect.sequenceEqual subject (["A";"B";"C"] |> List.toSeq) "should equal ['A';'B';'C']"
]
        ]
