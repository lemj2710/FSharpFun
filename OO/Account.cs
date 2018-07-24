using System.Collections.Generic;
using Util;

namespace OO
{
    public class Account
    {
        private readonly IEnumerable<IFund> funds;
        
        public Account(IEnumerable<IFund> funds)
        {
            this.funds = funds;
        }
        
        public decimal CalculateListTotal(Data data)
        {   
            var total = 0m;
            
            foreach (var fund in funds)
            {
                total += fund.Sum(data);
            }

            return total;
        }
    }
}