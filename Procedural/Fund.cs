using Util;

namespace Procedural
{
    public class Fund
    {
        // Method 1
        public decimal Process(string type, decimal total, decimal baseValue)
        {
            // Default value?
            var totalProcessed = 0m;
                
            // Mixed logic & duplicated logic?
            if (type == "interest" && total > 10)
            {
                totalProcessed = baseValue + total * Constante.RateAddI;
            }
            else if (type == "interest")
            {
                totalProcessed = baseValue + total * Constante.RateAddB;

                //var rate = (total > 10) ? Constante.RateAddI : Constante.RateAddB;
                //totalProcessed = baseValue + (total * rate);
            }
            else if (type == "investor")
            {
                totalProcessed = baseValue + total * Constante.RateEditB;
            }
            else if (type == "convert")
            {
                totalProcessed = total;
            }
            // missing default else ?
            
            return totalProcessed;
        }
        
        // Method 2 with similar code from method 1
        public decimal Sum(string type, Data data)
        {
            var sum = 0m;
                
            if (type == "interest")
            {
                sum = data.AmountUnites;
            }
            else if (type == "investor")
            {
                sum = data.AmountInvested;
            }
            else if (type == "convert")
            {
                sum = data.AmountUnites + data.AmountInvested;
            }
            
            return sum;
        }
    }
}