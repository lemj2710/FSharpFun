open Functionnal
open Util

[<EntryPoint>]
let main argv =
    App.StartApp argv
    
    let execute typeFund fct total = 
        match (Fund.make typeFund) with
        | Some typeOfFund -> sprintf "processFund %i" (fct typeOfFund total)
        | None -> "type not found"
    
    printfn (Printf.TextWriterFormat<_> (execute "interest" Fund.process 10))
    printfn (Printf.TextWriterFormat<_> (execute "interest" Fund.sum {amountUnites=1; amountInvested=1}))
    
    0 // return an integer exit code