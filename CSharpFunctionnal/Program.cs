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

            var fund = Fund.Make(args[1]);

            var process = Fund.Process(decimal.Parse(args[2]), decimal.Parse(args[2]));
            var sum = Fund.Sum(new Data(decimal.Parse(args[3]), decimal.Parse(args[3])));
            
            Console.WriteLine($"Process {Fund.Execute(process, fund)}");
            Console.WriteLine($"Sum {Fund.Execute(sum, fund)}");
        }
    }
}