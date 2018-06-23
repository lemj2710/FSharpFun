namespace Functionnal

open Procedural  

module Fund =
    open Util

    // this is a record, like tuple but with named property
    type Data = {amountUnites: int; amountInvested: int}
        
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
    
    // look a new type with a contructor with a parameter
    type Rate = RateValue of int
    
    // look here : "(*) value rate" could be wright like this "value * rate", just to show that * is a function
    let multiply value (RateValue rate) = (*) value rate
        
    // Module are object and are much like requirejs module
    module Interest =
        let getUnites {amountUnites=amountUnites; amountInvested=_} = amountUnites
        let getRate total = if total > 10 then RateValue Constante.RateAddI else RateValue Constante.RateAddB
    
    module Investor =
        let getInvested {amountUnites=_; amountInvested=amountInvested} = amountInvested

    module Convert =
        let getTotal {amountUnites=amountUnites; amountInvested=amountInvested} = amountUnites + amountInvested
                
    let process fund total = 
        match fund with 
        | Interest -> multiply total (Interest.getRate total)
        | Investor-> multiply total (RateValue Constante.RateEditB)
        | Convert -> total
                
    let sum typeFund data = 
        match typeFund with 
        | Interest -> Interest.getUnites data
        | Investor-> Investor.getInvested data
        | Convert -> Convert.getTotal data