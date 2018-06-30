namespace Util
{
    public class Rate
    {
        private readonly decimal _rate;
        
        public Rate(decimal rate)
        {
            _rate = rate;
        }
        
        public decimal Multiply(decimal value) => _rate * value;
    }
}