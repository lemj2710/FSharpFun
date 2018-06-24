open Functionnal
open Functionnal.Fund
open Util

[<EntryPoint>]
let main argv =
    printfn "Functionnal"
    
    // Seems familliar ... 
    App.StartApp argv
    
    let maybeAFund = Fund.make "interest"
    
    let process = Fund.process 10 10
    let sum = Fund.sum {amountUnites=1; amountInvested=1}
    
    printfn (Printf.TextWriterFormat<_> (execute process maybeAFund))
    printfn (Printf.TextWriterFormat<_> (execute sum maybeAFund))
    
    0 // return an integer exit code