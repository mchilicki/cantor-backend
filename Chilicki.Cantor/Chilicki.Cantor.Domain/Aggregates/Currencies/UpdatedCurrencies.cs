﻿using Chilicki.Cantor.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Domain.Aggregates.Currencies
{
    public class UpdatedCurrencies
    {
        public DateTime PublicationDate { get; set; }
        public virtual ICollection<Currency> Items { get; set; }
    }
}
