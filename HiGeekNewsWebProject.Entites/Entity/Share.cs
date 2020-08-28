using HiGeekNewsWebProject.Kernel.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Entites.Entity
{
    public class Share : KernelEntity
    {
        public Guid UserId { get; set; }
        public virtual AppUser User { get; set; }

        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
