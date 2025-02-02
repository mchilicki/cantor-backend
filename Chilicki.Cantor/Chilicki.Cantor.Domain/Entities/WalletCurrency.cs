﻿using Chilicki.Cantor.Domain.Entities.Base;

namespace Chilicki.Cantor.Domain.Entities
{
    public class WalletCurrency : BaseEntity
    {
        public virtual User Owner { get; set; }
        public virtual Currency Currency { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }
    }
}
