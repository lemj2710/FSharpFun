using System.Collections.Generic;
using Util;

namespace Procedural
{
    public static class Account
    {
        public static decimal CalculateListTotal(List<string> type, Data data)
        {
            var total = 0m;
            
            // loop over bound (lenght or count) when has that ever went wrong?
            for (var index = 0; index < type.Count; index++)
            {
                total += Fund.Sum(type[index], data);
            }

            return total;
        }
    }
}