using HiGeekNewsWebProject.Kernel.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Kernel.Mapping
{
    public abstract class KernelMap<T> : IEntityTypeConfiguration<T> where T : KernelEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status).IsRequired(true);

            builder.Property(x => x.CreateDate).IsRequired(true);
            builder.Property(x => x.CreatedComputerName).IsRequired(true);
            builder.Property(x => x.CreatedIp).IsRequired(true);
            builder.Property(x => x.CreatedBy).IsRequired(true);

            builder.Property(x => x.ModifiedIp).IsRequired(false);
            builder.Property(x => x.ModifiedDate).IsRequired(false);
            builder.Property(x => x.ModifiedComputerName).IsRequired(false);
            builder.Property(x => x.ModifiedBy).IsRequired(false);
        }
    }
}
