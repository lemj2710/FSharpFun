namespace Functionnal

open Fund
    
module Account =
    let CalculateListTotal data funds =
         funds |> List.map (sum data) |> List.sum