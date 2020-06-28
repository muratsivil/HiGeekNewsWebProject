using HiGeekNewsWebProject.Entites.Entity;
using HiGeekNewsWebProject.Kernel.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Map.Mapping.Entities
{
    public class AppUserMap : KernelMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.UserName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Password).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.PhoneNumber).HasMaxLength(15).IsRequired(false);
            builder.Property(x => x.Role).IsRequired(true);

            builder.HasMany(x => x.Posts)
                .WithOne(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Comments)
                .WithOne(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Likes)
               .WithOne(x => x.AppUser)
               .HasForeignKey(x => x.AppUserId)
               .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}
