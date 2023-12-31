﻿namespace Family.Budget.Infrastructure.Repositories.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Family.Budget.Infrastructure.Repositories.Common;
using Family.Budget.Domain.Entities.Admin;
public class ConfigurationConfig : IEntityTypeConfiguration<Configuration>
{
    public void Configure(EntityTypeBuilder<Configuration> entity)
    {
        entity.ToTable(nameof(Configuration), SchemasNames.FamilyBudget);
        entity.HasKey(k => k.Id);
        entity.Property(k => k.Name).HasMaxLength(100);
        entity.Property(k => k.Value).HasMaxLength(2500);
        entity.Property(k => k.Description).HasMaxLength(1000);
        entity.Ignore(k => k.Events);
    }
}
