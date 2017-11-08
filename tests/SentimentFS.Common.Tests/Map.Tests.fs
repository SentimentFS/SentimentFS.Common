namespace SentimentFS.Common.Tests

module Map =

    open Expecto
    open SentimentFS.Common
    open SentimentFS.Common.Map


    [<Tests>]
    let mapTest =
        testList "Map" [
            testList "mapWords" [
                testCase "when empty" <| fun _ ->
                    let subject = [] |> mapValues(1)
                    Expect.equal subject ([] |> Map.ofList) "should be empty"
                testCase "when list has one element" <| fun _ ->
                    let subject = mapValues(1) ["test"]
                    Expect.equal subject ([("test", 1)] |> Map.ofList) "should eq {test: 1}"
                testCase "when list has two the same element" <| fun _ ->
                    let subject = mapValues(1) ["test"; "test"]
                    Expect.equal subject ([("test", 2)] |> Map.ofList) "should eq {test: 2}"
                testCase "when list has two the same element and value is greater than 0" <| fun _ ->
                    let subject = mapValues(5) ["test"; "test"]
                    Expect.equal subject ([("test", 10)] |> Map.ofList) "should eq {test: 2}"
            ]
            testList "merge" [
                testCase "second map" <| fun _ ->
                    let map1 = ([(1,1); (2,2)] |> Map.ofList)
                    let map2 = ([(1,2); (2,3)] |> Map.ofList)
                    let subject = Map.merge (fun (key,v1,v2) -> v2) map1 map2
                    Expect.equal subject ([(1,2); (2,3)] |> Map.ofList) "should get key only from second map"
                testCase "first map" <| fun _ ->
                    let map1 = ([(1,1); (2,2)] |> Map.ofList)
                    let map2 = ([(1,2); (2,3)] |> Map.ofList)
                    let subject = Map.merge (fun (key,v1,v2) -> v1) map1 map2
                    Expect.equal subject ([(1,1); (2,2)]  |> Map.ofList) "should get key only from first map"
                testCase "sum values" <| fun _ ->
                    let map1 = ([(1,1); (2,2)] |> Map.ofList)
                    let map2 = ([(1,2); (2,3)] |> Map.ofList)
                    let subject = Map.merge (fun (key,v1,v2) -> v1 + v2) map1 map2
                    Expect.equal subject ([(1,3); (2,5)] |> Map.ofList) "should return sum of values"
                testCase "first map is greater" <| fun _ ->
                    let map1 = ([(1,1); (2,2); (3,3)] |> Map.ofList)
                    let map2 =  ([(1,2); (2,3)] |> Map.ofList)
                    let subject = Map.merge (fun (key,v1,v2) -> v2) map1 map2
                    Expect.equal subject ([(1,2); (2,3);(3,3)] |> Map.ofList) "should get elements that exist in both maps from second map and rest from greater"
            ]
            testList "accumulateAll" [
                testCase "test" <| fun _ ->
                    let subject = ([(1,1); (2,2)] |> Map.ofList) |> Map.accumulateAllValues
                    Expect.equal subject 3 "should equal"
                testCase "test2" <| fun _ ->
                    let subject = ([(1,1); (2,2);(3,3)] |> Map.ofList) |> Map.accumulateAllValues
                    Expect.equal subject 6 "should equal"
            ]
            testList "take" [
                testCase "test" <| fun _ ->
                    let subject = ([("a",1); ("b",2)] |> Map.ofList) |> Map.take (["a"])
                    Expect.equal subject ([("a",1)] |> Map.ofList) "should equal"
            ]
]
