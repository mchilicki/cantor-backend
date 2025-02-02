﻿using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Configurations.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chilicki.Cantor.Infrastructure.Configurations.EntityConfigurations
{
    public class CantorCurrencyConfiguration : BaseEntityConfiguration<CantorCurrency>
    {
        public override void ConfigureEntity(EntityTypeBuilder<CantorCurrency> builder)
        {
            builder
                .HasOne(p => p.CantorWallet)
                .WithMany(p => p.CantorCurrencies)
                .HasForeignKey("CantorId")
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
