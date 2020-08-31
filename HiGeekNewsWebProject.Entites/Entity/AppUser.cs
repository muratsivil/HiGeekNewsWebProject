using HiGeekNewsWebProject.Kernel.Enums;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiGeekNewsWebProject.Entites.Entity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Roles Roles { get; set; }

        // This part cames from KernelEntity
        public DateTime CreateDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIp { get; set; }
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedIp { get; set; }
        public string ModifiedBy { get; set; }

        public Status Status { get; set; }
        /***********************************/

        public string ImagePath { get; set; }
        public string UserImage { get; set; }
        public string XSmallUserImage { get; set; }
        public string CruptedUserImage { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Share> Shares { get; set; }

        [InverseProperty("FollowerUser")]
        public virtual ICollection<Follow> Followers { get; set; }

        [InverseProperty("FollowingUser")]
        public virtual ICollection<Follow> Following { get; set; }
    }
}
