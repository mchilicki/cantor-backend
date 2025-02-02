﻿using Chilicki.Cantor.Infrastructure.Configurations.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Chilicki.Cantor.Infrastructure.Databases
{
    public class CantorDatabaseContext : DbContext
    {
        public CantorDatabaseContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CantorCurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new CantorWalletConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new WalletCurrencyConfiguration());
        }
    }
}
