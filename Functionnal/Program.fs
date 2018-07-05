open Functionnal
open Functionnal.Fund
open Functionnal.Account

open Util

[<EntryPoint>]
let main argv =
    printfn "Functionnal"
    
    // Seems familliar ... 
    App.StartApp argv
    
    let maybeAFund = Fund.make 10 "interest"
    
    let types = [ maybeAFund; maybeAFund; Fund.make 10 "error" ]
    let data = {amountUnites=1; amountInvested=1}

    let sumValue = types |> CalculateListTotal data;
                
    // Which style should I use?
    Fund.process 10 10 maybeAFund |> sprintf "%i" |> Printf.TextWriterFormat<_> |> printfn
    
    printfn (Printf.TextWriterFormat<_> (sprintf "%i" sumValue))
    
    0 // return an integer exit code