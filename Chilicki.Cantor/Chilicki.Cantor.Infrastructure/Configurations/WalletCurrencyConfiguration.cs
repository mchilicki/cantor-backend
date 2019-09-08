using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chilicki.Cantor.Infrastructure.Configurations
{
    public class WalletCurrencyConfiguration : BaseEntityConfiguration<WalletCurrency>
    {
        public override void ConfigureEntity(EntityTypeBuilder<WalletCurrency> builder)
        {
            builder
                .HasOne(p => p.Owner)
                .WithMany(p => p.Currencies)
                .HasForeignKey("OwnerId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(p => p.Currency)
                .WithMany()
                .HasForeignKey("CurrencyId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
