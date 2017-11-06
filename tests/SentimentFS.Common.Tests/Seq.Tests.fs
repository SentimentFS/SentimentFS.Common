namespace SentimentFS.Common.Tests

module Seq =

    open Expecto
    open SentimentFS.Common

    [<Tests>]
    let tests =
        testList "List" [
            testList "filterOut" [
                testCase "delete when elements exist in  filter list" <| fun _ ->
                    let subject = ["A"; "B"; "C"] |> Seq.filterOut ["C"]
                    Expect.equal subject (["A";"B"] |> List.toSeq) "should equal ['A';'B']"
                testCase "delete when elements no exist in filter list" <| fun _ ->
                    let subject = ["A"; "B"; "C"] |> Seq.filterOut ["D"]
                    Expect.equal subject (["A";"B";"C"] |> List.toSeq) "should equal ['A';'B';'C']"
]
        ]
