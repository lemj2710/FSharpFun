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
            var sumValue = fund.Sum(new Data(decimal.Parse(args[3]), decimal.Parse(args[3])));
            
            System.Console.WriteLine($"Process {processValue}");
            System.Console.WriteLine($"Sum {sumValue}");
        }
    }
}