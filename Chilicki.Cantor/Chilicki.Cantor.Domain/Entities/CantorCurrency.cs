using Chilicki.Cantor.Domain.Entities.Base;

namespace Chilicki.Cantor.Domain.Entities
{
    public class CantorCurrency : BaseEntity
    {
        public virtual CantorWallet CantorWallet { get; set; }
        public virtual Currency Currency { get; set; }
        public int Amount { get; set; }
    }
}
