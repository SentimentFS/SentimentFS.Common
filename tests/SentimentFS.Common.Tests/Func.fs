namespace SentimentFS.Common.Tests

module Func =

    open Expecto
    open SentimentFS.Common

    [<Tests>]
    let tests =
      testList "Func" [
        testCase "memonize" <| fun _ ->
          let mutable executed = 0
          let test x =
            executed <- executed + 1
            x
          let func = Func.memonize test
          let firstTimeExecution = func 1
          let secondTimeExecution = func 1
          Expect.equal executed 1 "Execution count should equal 1"
      ]
