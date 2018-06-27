using Procedural;
using Util;

// Is there any advantage
namespace CSharpFunctionnal
{
    public interface IFund { }
    public class FundConvert: IFund { }

    public class FundInterest : IFund
    {
        public decimal Rate(decimal total) => (total > 10) ? Constante.RateAddI : Constante.RateAddB;
    }

    public class FundInvestor : IFund
    {
        public const decimal Rate = Constante.RateEditB;
    }
    
    public class Fund
    {
        // FACTORY METHOD
        public static (IFund, bool) Make(string type)
        {
            var isError = false;
            IFund fundType = null;
            
            switch (type)
            {
                case "interest":
                    fundType = new FundInterest();
                    break;
                case "investor":
                    fundType = new FundInvestor();
                    break;
                case "convert":
                    fundType = new FundConvert();
                    break;
                default:
                    // should we throw a exception?
                    System.Console.WriteLine($"Not found Fund {type}");
                    isError = true;
                    break;
            }

            return (fundType, isError);
        }
        
        public static decimal Sum(IFund fund, Data data)
        {
            var (amountUnites, amountInvested) = data;

            decimal total = 0;
            
            switch (fund)
            {
                case FundInterest f:
                    total = amountUnites;
                    break;
                case FundInvestor f:
                    total = amountInvested;
                    break;
                case FundConvert f:
                    total = amountUnites + amountInvested;
                    break;
            }

            return total;
        }
        
        public static decimal Process(IFund fund, decimal total, decimal baseValue)
        {
            decimal value = 0;
            
            switch (fund)
            {
                case FundInterest f:
                    value = baseValue + total * f.Rate(total);
                    break;
                case FundInvestor f:
                    value = baseValue + total * FundInvestor.Rate;
                    break;
                case FundConvert f:
                    value = total;
                    break;
            }

            return value;
        }
    }
}