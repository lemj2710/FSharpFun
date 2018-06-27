namespace Util
{
    public class Data
    {
        public decimal AmountUnites;
        public decimal AmountInvested;

        public Data(decimal amountUnites, decimal amountInvested)
        {
            AmountUnites = amountUnites;
            AmountInvested = amountInvested;
        }
        
        public void Deconstruct(out decimal amountUnites, out decimal amountInvested)
        {
            amountUnites = AmountUnites;
            amountInvested = AmountInvested;
        }
    }
}