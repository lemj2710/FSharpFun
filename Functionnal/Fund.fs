namespace Functionnal

open Rate
    
module Fund =
    // This is a union type , TypeFund is like a Interface without definition for method
    type TypeFund =
        | Interest of Rate
        | Investor of Rate
        | Convert
        
    // Here my factory
    let make total fund =
        match fund with  
        | "interest" -> Rate.Interest.rate total |> Interest |> Some
        | "investor" -> Some (Investor Rate.Investor.rate)
        | "convert" -> Some Convert
        | _ -> None
    
    let process total baseValue fund = 
        match fund with 
        | Some (Interest (Rate rate)) 
        | Some (Investor (Rate rate)) -> (*) rate total |> (+) baseValue // rate * total + baseValue
        | Some Convert -> total
        | None -> 0
        
    // this is a record, like tuple but with named property 
    // type Data = int*int
    type Data = {amountUnites: int; amountInvested: int}
                
    let sum {amountUnites=amountUnites; amountInvested=amountInvested} fund = 
        match fund with 
        | Some (Interest _) -> amountUnites
        | Some (Investor _) -> amountInvested
        | Some Convert -> amountUnites + amountInvested
        | None -> 0
        
    // What is the difference between the sum function and the equivalent procedural function?
    
    // IS this program lying? 
    // Count the number of defect