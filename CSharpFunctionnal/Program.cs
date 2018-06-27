using System;
using Util;

namespace CSharpFunctionnal
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("CSharpFunctionnal");
            App.StartApp(args);

            var (fund, isError) = Fund.Make(args[1]);

            if (isError) throw new Exception($"Cannot make fund with {args[1]}");
            
            var processValue = Fund.Process(fund, decimal.Parse(args[2]), decimal.Parse(args[2]));
            var sumValue = Fund.Sum(fund, new Data(decimal.Parse(args[3]), decimal.Parse(args[3])));
            
            Console.WriteLine($"Process {processValue}");
            Console.WriteLine($"Sum {sumValue}");
        }
    }
}