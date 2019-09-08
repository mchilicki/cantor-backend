using System;

namespace Chilicki.Cantor.Domain.Entities.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
