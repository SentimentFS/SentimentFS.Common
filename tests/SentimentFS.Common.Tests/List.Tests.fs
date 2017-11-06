namespace SentimentFS.Common.Tests

module List =

    open Expecto
    open SentimentFS.Common

    [<Tests>]
    let tests =
        testList "List" [
            testList "filterOut" [
                testCase "delete when elements exist in  filter list" <| fun _ ->
                    let subject = ["A"; "B"; "C"] |> List.filterOut ["C"]
                    Expect.equal subject ["A";"B"] "should equal ['A';'B']"
                testCase "delete when elements no exist in filter list" <| fun _ ->
                    let subject = ["A"; "B"; "C"] |> List.filterOut ["D"]
                    Expect.equal subject ["A";"B";"C"] "should equal ['A';'B';'C']"
            ]
        ]
