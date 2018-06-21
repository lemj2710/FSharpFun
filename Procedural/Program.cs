using Util;

namespace Procedural
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            App.StartApp(args);
            
            System.Console.WriteLine($"Process {new Fund().Process(args[1], decimal.Parse(args[2]))}");
            System.Console.WriteLine($"Process {new Fund().Sum(args[1], new Data(decimal.Parse(args[3]), decimal.Parse(args[3])))}");
        }
    }
}