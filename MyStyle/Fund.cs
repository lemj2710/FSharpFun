using System;
using Procedural;
using Util;

namespace MyStyle
{
    public interface IFund
    {
        decimal Process(decimal total, decimal baseValue);
    }

    public class FundConvert : IFund
    {
        public decimal Process(decimal total, decimal baseValue) =>
            total;
    }

    public class FundInterest : IFund
    {
        public decimal Process(decimal total, decimal baseValue) =>
            baseValue + Rate(total).Multiply(total);
        
        private static Rate Rate(decimal total) => 
            (total > 10) ? new Rate(Constante.RateAddI) : new Rate(Constante.RateAddB);
    }

    public class FundInvestor : IFund
    {
        public decimal Process(decimal total, decimal baseValue) =>
            baseValue + Constante.RateEditB * total;
    }
    
    public static class Fund
    {
        public static Option<IFund> Make(string type)
        {
            Option<IFund> fundType;
            
            switch (type)
            {
                case "interest":
                    fundType = new Some<IFund>(new FundInterest());
                    break;
                case "investor":
                    fundType = new Some<IFund>(new FundInvestor());
                    break;
                case "convert":
                    fundType = new Some<IFund>(new FundConvert());
                    break;
                default:
                    fundType = new None<IFund>();
                    break;
            }

            return fundType;
        }

        public static string Execute(Func<IFund, decimal> task, Option<IFund> fund) =>
            fund.Match((f) => $"processFund {task(f)}", () => "type not found");
        
        public static Func<IFund, decimal> Sum(Data data) =>
            (fund) =>
                {
                    var total = 0m;
                    
                    switch (fund)
                    {
                        case FundInterest f:
                            total = data.AmountUnites;
                            break;
                        case FundInvestor f:
                            total = data.AmountInvested;
                            break;
                        case FundConvert f:
                            total = data.AmountUnites + data.AmountInvested;
                            break;
                    }
    
                    return total;
                };
        
        public static Func<IFund, decimal> Process(decimal total, decimal baseValue) =>
            (fund) => fund.Process(total, baseValue);
    }
}