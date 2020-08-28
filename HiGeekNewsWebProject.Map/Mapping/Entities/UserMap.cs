using HiGeekNewsWebProject.Entites.Entity;
using HiGeekNewsWebProject.Kernel.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Map.Mapping.Entities
{
    public class UserMap<T> : IEntityTypeConfiguration<AppUser> where T : AppUser
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
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

            builder.Property(x => x.FirstName).IsRequired(true);
            builder.Property(x => x.LastName).IsRequired(true);

            builder.HasMany(x => x.Posts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Comments)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Likes)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Shares)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Followers)
                .WithOne(x => x.FollowerUser)
                .HasForeignKey(x => x.FollowerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Following)
                 .WithOne(x => x.FollowingUser)
                 .HasForeignKey(x => x.FollowingId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
