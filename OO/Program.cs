using System.Collections.Generic;
using Util;

namespace OO
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            System.Console.WriteLine($"OO");
            App.StartApp(args);

            var fund = Fund.Make(args[1]);

            var processValue = fund.Process(decimal.Parse(args[2]), decimal.Parse(args[2]));

            var typeArray = new List<IFund> { Fund.Make(args[1]), Fund.Make(args[1]), Fund.Make("error")};

            var data = new Data(decimal.Parse(args[3]), decimal.Parse(args[3]));
                
            var sumValue = new Account(typeArray).CalculateListTotal(data);

            System.Console.WriteLine($"Process {processValue}");
            System.Console.WriteLine($"Sum {sumValue}");
        }
    }
}