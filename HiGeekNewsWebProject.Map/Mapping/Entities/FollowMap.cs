using HiGeekNewsWebProject.Entites.Entity;
using HiGeekNewsWebProject.Kernel.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Map.Mapping.Entities
{
    public class FollowMap : KernelMap<Follow>
    {
        public override void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.HasOne(x => x.FollowingUser)
                .WithMany(x => x.Following)
                .HasForeignKey(x => x.FollowingId);

            builder.HasOne(x => x.FollowerUser)
                .WithMany(x => x.Followers)
                .HasForeignKey(x => x.FollowerId);

            base.Configure(builder);
        }
    }
}
