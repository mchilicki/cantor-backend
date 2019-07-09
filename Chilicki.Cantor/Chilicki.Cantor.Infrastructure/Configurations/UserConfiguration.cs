using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Infrastructure.Configurations
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void ConfigureEntity<TConfiguredEntity>(EntityTypeBuilder<TConfiguredEntity> builder)
        {
            
        }
    }
}
