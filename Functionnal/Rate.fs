namespace Functionnal

open Procedural

module Rate =
    // look a new type with a contructor with a parameter
    type Rate = Rate of int
    
    // look here : "(*) value rate" could be wright like this "value * rate", just to show that * is a function
    let multiply value (Rate rate) = (*) value rate
    
    // Module are object and are much like requirejs module or static class
    module Interest =
        let rate total = if total > 10 then Rate.Rate Constante.RateAddI else Rate.Rate Constante.RateAddB
        
    module Investor =
        let rate = Rate.Rate Constante.RateEditB