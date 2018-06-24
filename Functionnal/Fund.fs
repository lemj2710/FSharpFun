namespace Functionnal

open Rate
    
module Fund =
    // This is a union type , TypeFund is like a Interface without definition for method
    type TypeFund =
        | Interest
        | Investor
        | Convert
         
    // Here my factory
    // function is syntactic sugar for let make parameter = match parameter with ...
    let make = function 
        | "interest" -> Some Interest
        | "investor" -> Some Investor
        | "convert" -> Some Convert
        | _ -> None
    
    let execute task maybeAFund = 
        match maybeAFund with
        | Some fund -> sprintf "processFund %i" (task fund)
        | None -> "type not found"
        
    let process total baseValue fund = 
        match fund with 
        | Interest -> baseValue + Rate.multiply total (Rate.Interest.rate total)
        | Investor -> baseValue + Rate.multiply total Rate.Investor.rate
        | Convert -> total
        
    // this is a record, like tuple but with named property 
    // type Data = int*int
    type Data = {amountUnites: int; amountInvested: int}
                
    let sum {amountUnites=amountUnites; amountInvested=amountInvested} fund = 
        match fund with 
        | Interest -> amountUnites
        | Investor -> amountInvested
        | Convert -> amountUnites + amountInvested
        
    // What is the difference between the sum function and the equivalent procedural function?