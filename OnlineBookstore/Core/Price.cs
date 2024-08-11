namespace OnlineBookstore.Core
{
    public class Price
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        private Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Price Create(decimal amount, string currency)
        {
            validate(amount);
            return  new Price(amount, currency);
        }


        private static void validate(decimal price)
        {

            if (price <= 0)
            {
                throw new Exception("Invalid Price");
            }

        }
    }
}
