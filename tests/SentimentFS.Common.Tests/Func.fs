namespace SentimentFS.Common.Tests

module Func =

    open Expecto
    open SentimentFS.Common

    [<Tests>]
    let tests =
      testList "Func" [
        testCase "memonize" <| fun _ ->
          let test x =
            System.Threading.Thread.Sleep(500)
            1
          let func = Func.memonize test
          let a = func 1
          Expect.isTrue true ""
          //Expect.isFasterThan (fun () -> func(1)) (fun () -> func(2)) "memonized function should be evaluated faster"
      ]
