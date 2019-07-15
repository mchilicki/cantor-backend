using Chilicki.Cantor.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Aggregates
{
    public class UpdatedCurrencies
    {
        public DateTime PublicationDate { get; set; }
        public ICollection<Currency> Items { get; set; }
    }
}
