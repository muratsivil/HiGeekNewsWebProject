using HiGeekNewsWebProject.Entites.Entity;
using HiGeekNewsWebProject.Kernel.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Map.Mapping.Entities
{
    public class ShareMap : KernelMap<Share>
    {
        public override void Configure(EntityTypeBuilder<Share> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.Shares)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Shares)
                .HasForeignKey(x => x.PostId);


            base.Configure(builder);
        }
    }
}
