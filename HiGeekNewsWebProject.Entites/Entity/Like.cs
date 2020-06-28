using HiGeekNewsWebProject.Kernel.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Entites.Entity
{
    public class Like : KernelEntity
    {
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
