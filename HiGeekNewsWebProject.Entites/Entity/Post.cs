using HiGeekNewsWebProject.Kernel.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Entites.Entity
{
    public class Post : KernelEntity
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public DateTime? PublishDate { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Guid UserId { get; set; }
        public virtual AppUser User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Share> Shares { get; set; }
    }
}
