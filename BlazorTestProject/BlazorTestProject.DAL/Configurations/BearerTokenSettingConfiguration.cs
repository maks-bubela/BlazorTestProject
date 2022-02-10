﻿using BlazorTestProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorTestProject.DAL.Configurations
{
    public class BearerTokenSettingConfiguration : IEntityTypeConfiguration<BearerTokenSetting>
    {
        public void Configure(EntityTypeBuilder<BearerTokenSetting> builder)
        {
            builder.HasOne(b => b.EnvironmentType)
                .WithMany(e => e.BearerTokenSettings)
                .HasForeignKey(b => b.EnvironmentTypeId).IsRequired();
        }
    }
}
