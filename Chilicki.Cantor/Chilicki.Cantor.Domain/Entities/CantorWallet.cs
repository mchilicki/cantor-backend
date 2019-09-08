using Chilicki.Cantor.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Entities
{
    public class CantorWallet : BaseEntity
    {
        public DateTime PublicationDate { get; set; }
        public virtual ICollection<CantorCurrency> CantorCurrencies { get; set; }
    }
}
