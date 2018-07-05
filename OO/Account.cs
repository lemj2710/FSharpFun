using System.Collections.Generic;
using Util;

namespace OO
{
    public static class Account
    {
        public static decimal CalculateListTotal(IEnumerable<IFund> funds, Data data)
        {   
            var total = 0m;
            
            foreach (var fund in funds)
            {
                System.Console.WriteLine("loop");
                total += fund.Sum(data);
            }

            return total;
        }
    }
}