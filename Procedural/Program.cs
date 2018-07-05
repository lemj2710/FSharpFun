using System.Collections.Generic;
using Util;

namespace Procedural
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            System.Console.WriteLine($"Procedural");
            App.StartApp(args);

            var processValue = Fund.Process(args[1], decimal.Parse(args[2]), decimal.Parse(args[2]));
            
            
            var typeArray = new List<string> { args[1], args[1], "error" };

            var data = new Data(decimal.Parse(args[3]), decimal.Parse(args[3]));

            var sumValue = Account.CalculateListTotal(typeArray, data);
            
            System.Console.WriteLine($"Process {processValue}");
            System.Console.WriteLine($"Sum {sumValue}");
        }
    }
}