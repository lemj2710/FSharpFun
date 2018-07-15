using System.Collections.Generic;
using System.Linq;
using Util;

namespace CSharpFunctionnal
{
    public static class Account
    {
        public static decimal CalculateListTotal(IEnumerable<Option<IFund>> funds, Data data) =>
            funds.Sum(Fund.MapAndSum(data));
    }
}