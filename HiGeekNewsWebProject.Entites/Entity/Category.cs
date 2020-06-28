using HiGeekNewsWebProject.Kernel.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Entites.Entity
{
    public class Category : KernelEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
