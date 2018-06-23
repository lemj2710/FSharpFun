open Functionnal
open Functionnal.Fund
open Util

[<EntryPoint>]
let main argv =
    printfn "Functionnal"
    
    // Seems familliar ... 
    App.StartApp argv
    
    let execute task fund = 
        match fund with
        | Some typeFund -> sprintf "processFund %i" (task typeFund)
        | None -> "type not found"
    
    let fund = Fund.make "interest"
    
    let process = Fund.process 10 10
    let sum = Fund.sum {amountUnites=1; amountInvested=1}
    
    printfn (Printf.TextWriterFormat<_> (execute process fund))
    printfn (Printf.TextWriterFormat<_> (execute sum fund))
    
    0 // return an integer exit code