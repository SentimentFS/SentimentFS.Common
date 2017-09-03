namespace SentimentFS.Common.Tests

module Func =

    open Expecto
    open SentimentFS.Common

    [<Tests>]
    let tests =
      testList "Func" [
        testCase "memonize" <| fun _ ->
          let square x =
            System.Threading.Thread.Sleep(100)
            x * x
          let func = Func.memonize square
          let a = func 1.0f
          Expect.isFasterThan (fun () -> func(1.0f)) (fun () -> func(1.2f)) "memonized function shold be evaluated faster"
      ]
