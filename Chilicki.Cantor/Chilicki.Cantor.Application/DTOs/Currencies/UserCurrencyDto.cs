namespace Chilicki.Cantor.Application.DTOs.Currencies
{
    public class UserCurrencyDto : CurrencyDto
    {
        public decimal SellPrice { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }
    }
}
