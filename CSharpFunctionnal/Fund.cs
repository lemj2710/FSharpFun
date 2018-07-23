using System;
using Procedural;
using Util;

namespace CSharpFunctionnal
{
    public interface IFund { }
    public class FundConvert: IFund { }
    public class FundInterest : IFund
    {
        public readonly Rate Rate;
        
        public FundInterest(Rate rate)
        {
            Rate = rate;
        }
    }
    public class FundInvestor : IFund
    {
        public readonly Rate Rate;

        public FundInvestor(Rate rate)
        {
            Rate = rate;
        }
    }
    
    public static class Fund
    {
        // FACTORY METHOD
        public static Option<IFund> Make(string type, decimal total)
        {
            Option<IFund> fundType;
            
            switch (type)
            {
                case "interest":
                    var rate = (total > 10) ? new Rate(Constante.RateAddI) : new Rate(Constante.RateAddB);
                    fundType = new Some<IFund>(new FundInterest(rate));
                    break;
                case "investor":
                    fundType = new Some<IFund>(new FundInvestor(new Rate(Constante.RateEditB)));
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

        //public static Option<decimal> Process(Func<IFund, decimal> task, Option<IFund> fund) =>
        //    fund.Bind(task);
        
        public static Func<Option<IFund>, decimal> MapAndSum(Data data) =>
            (fund) => fund.Match(Sum(data), () => 0);

        private static Func<IFund, decimal> Sum(Data data) =>
            (fund) =>
                {
                    var (amountUnites, amountInvested) = data;
    
                    var total = 0m;
    
                    switch (fund)
                    {
                        case FundInterest _:
                            total = amountUnites;
                            break;
                        case FundInvestor _:
                            total = amountInvested;
                            break;
                        case FundConvert _:
                            total = amountUnites + amountInvested;
                            break;
                    }
    
                    return total;
                };
        
        public static Func<IFund, decimal> Process(decimal total, decimal baseValue) =>
            (fund) =>
                {
                    var value = 0m;
                
                    switch (fund)
                    {
                        case FundInterest f:
                            value = baseValue + f.Rate.Multiply(total);
                            break;
                        case FundInvestor f:
                            value = baseValue + f.Rate.Multiply(total);
                            break;
                        case FundConvert _:
                            value = total;
                            break;
                    }
    
                    return value;
                };
    }
}

// Is there any advantage