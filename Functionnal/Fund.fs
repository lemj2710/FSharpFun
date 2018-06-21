namespace Functionnal

open Procedural  

module Fund =
    open Util

    type Data = {amountUnites: int; amountInvested: int}
        
    type TypeFund =
        | Interest
        | Investor
        | Convert
        
    let make = function 
        | "interest" -> Some Interest
        | "investor" -> Some Investor
        | "convert" -> Some Convert
        | _ -> None
        
    type Rate = RateValue of int
    
    let multiply value (RateValue rate) = (*) value rate
        
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