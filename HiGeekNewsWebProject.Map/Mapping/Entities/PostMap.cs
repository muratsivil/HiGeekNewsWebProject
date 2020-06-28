using HiGeekNewsWebProject.Entites.Entity;
using HiGeekNewsWebProject.Kernel.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Map.Mapping.Entities
{
    public class PostMap : KernelMap<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Content).HasMaxLength(140).IsRequired(true);
            builder.Property(x => x.ImagePath).IsRequired(true);
            base.Configure(builder);
        }
    }
}
