﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSA.Domain.Entities;

namespace OSA.Domain.EntityConfigurations
{
    //public class BatchConfiguration: EntityTypeConfiguration<Batch>
    //{
    //    public BatchConfiguration()
    //    {
    //        HasIndex(b => b.Name).IsUnique();
    //    }
    //}
    public class BatchConfiguration : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder)
        {
            builder.HasIndex(b => b.Name).IsUnique();
        }
    }
}
