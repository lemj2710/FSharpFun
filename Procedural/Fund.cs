using Util;

namespace Procedural
{
    public class Fund
    {
        // Method 1
        public decimal Process(string type, decimal total)
        {
            var totalProcessed = 0m;
                
            if (type == "interest" && total > 10)
            {
                totalProcessed = total * Constante.RateAddI;
            }
            else if (type == "interest")
            {
                totalProcessed = total * Constante.RateAddB;
            }
            else if (type == "investor")
            {
                totalProcessed = total * Constante.RateEditB;
            }
            else if (type == "convert")
            {
                totalProcessed = total;
            }
            
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