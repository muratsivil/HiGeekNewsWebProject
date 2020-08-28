using HiGeekNewsWebProject.Entites.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Associate.DTOs
{
    public class CommentDTO : BaseDTO
    {
        public string Content { get; set; }

        public Guid UserId { get; set; }
        public virtual AppUser User { get; set; }

        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
