using System;

namespace Chilicki.Cantor.Application.DTOs.Currencies
{
    public class CurrencyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Unit { get; set; }
    }
}
