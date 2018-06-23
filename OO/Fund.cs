using Procedural;
using Util;

namespace OO
{
    public interface IFund
    {
        decimal Sum(Data data);
        decimal Process(decimal total);
    }
    
    public class Fund
    {
        public decimal Process(string type, decimal total) => Make(type).Process(total);
        public decimal Sum(string type, Data data) => Make(type).Sum(data);
        
        // FACTORY METHOD
        public static IFund Make(string type)
        {
            /*
             * null?
             */
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
                    // should we throw a exception
                    System.Console.WriteLine($"Not found Fund {type}");
                    break;
            }

            return fundType;
        }
    }
   
    // Separate logic by Type
    public class FundConvert : IFund
    {
        public decimal Sum(Data data) => data.AmountUnites + data.AmountInvested;
        public decimal Process(decimal total) => total;
    }
        
    // Separate logic by Type
    public class FundInterest : IFund
    {
        public decimal Sum(Data data) => data.AmountUnites;
        public decimal Process(decimal total) => GetRate(total) * total;
        
        private int GetRate(decimal total) => (total > 10) ? Constante.RateAddI : Constante.RateAddB;
    }
        
    // Separate logic by Type
    public class FundInvestor : IFund
    {
        public decimal Sum(Data data) => data.AmountInvested;
        public decimal Process(decimal total) => total * Constante.RateEditB;
    }
}