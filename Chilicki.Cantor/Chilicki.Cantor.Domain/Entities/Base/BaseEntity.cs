using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Domain.Entities.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public byte[] Rowversion { get; set; }
    }
}
