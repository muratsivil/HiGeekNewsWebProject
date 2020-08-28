using HiGeekNewsWebProject.Entites.Entity;
using HiGeekNewsWebProject.Kernel.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Map.Mapping.Entities
{
    public class CategoryMap : KernelMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(250).IsRequired(false);

            builder.HasMany(x => x.Posts)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            base.Configure(builder);
        }
    }
}
