using HiGeekNewsWebProject.Kernel.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HiGeekNewsWebProject.Entites.Entity
{
    public class Follow : KernelEntity
    {
        [ForeignKey("FollowerUser")]
        public Guid FollowerId { get; set; }
        public virtual AppUser FollowerUser { get; set; }

        [ForeignKey("FollowingUser")]
        public Guid FollowingId { get; set; }
        public virtual AppUser FollowingUser { get; set; }

    }
}
