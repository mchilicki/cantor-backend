using Chilicki.Cantor.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Domain.Entities
{
    public class Currency : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Unit { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellPrice { get; set; }
        public decimal AveragePrice { get; set; }
    }
}
