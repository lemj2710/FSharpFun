using System;
using System.Collections.Generic;
using Util;

namespace CSharpFunctionnal
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("CSharpFunctionnal");
            App.StartApp(args);

            var fund = Fund.Make(args[1], decimal.Parse(args[2]));

            var process = Fund.Process(decimal.Parse(args[2]), decimal.Parse(args[2]));

            var types = new List<Option<IFund>> { fund, fund, Fund.Make("", decimal.Parse(args[2]))};
            var data = new Data(decimal.Parse(args[3]), decimal.Parse(args[3]));
            
            var sum = Account.CalculateListTotal(types, data);
            
            Console.WriteLine($"Process {fund.Bind(process)}"); //Console.WriteLine($"Process {Fund.Process(process, fund)}");
            Console.WriteLine($"Sum {sum}");
        }
    }
}