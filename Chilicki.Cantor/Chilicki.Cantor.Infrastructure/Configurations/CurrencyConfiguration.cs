using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chilicki.Cantor.Infrastructure.Configurations
{
    public class CurrencyConfiguration : BaseEntityConfiguration<Currency>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Currency> builder)
        {
            builder
                .Property(p => p.Code)
                .IsRequired();
            builder
                .Property(p => p.Name)
                .IsRequired();
        }
    }
}
