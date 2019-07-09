using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chilicki.Cantor.Domain.Entities.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
