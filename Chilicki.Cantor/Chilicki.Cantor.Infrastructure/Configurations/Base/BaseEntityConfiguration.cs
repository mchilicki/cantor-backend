﻿using Chilicki.Cantor.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Infrastructure.Configurations.Base
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .HasKey(p => p.Id);
            builder
                .Property(p => p.Id)
                .HasDefaultValueSql("newsequentialid()");            
            builder
                .Property(p => p.RowVersion)
                .IsRowVersion();
            ConfigureEntity(builder);
        }

        public abstract void ConfigureEntity<TConfiguredEntity>(EntityTypeBuilder<TConfiguredEntity> builder) where TConfiguredEntity : BaseEntity;
    }
}
