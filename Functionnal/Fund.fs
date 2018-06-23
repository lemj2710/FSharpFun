namespace Functionnal

open Rate
    
module Fund =
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
    
    let process fund total = 
        match fund with 
        | Interest -> Rate.multiply total (Rate.Interest.rate total)
        | Investor-> Rate.multiply total Rate.Investor.rate
        | Convert -> total
        
    // this is a record, like tuple but with named property 
    // type Data = int*int
    type Data = {amountUnites: int; amountInvested: int}
                
    let sum fund {amountUnites=amountUnites; amountInvested=amountInvested} = 
        match fund with 
        | Interest -> amountUnites
        | Investor-> amountInvested
        | Convert -> amountUnites + amountInvested