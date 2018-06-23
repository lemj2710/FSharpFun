using Util;

namespace Procedural
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            App.StartApp(args);

            var fund = new Fund();

            var processValue = fund.Process(args[1], decimal.Parse(args[2]), decimal.Parse(args[2]));
            var sumValue = fund.Sum(args[1], new Data(decimal.Parse(args[3]), decimal.Parse(args[3])));
            
            System.Console.WriteLine($"Process {processValue}");
            System.Console.WriteLine($"Sum {sumValue}");
        }
    }
}