using HiGeekNewsWebProject.Associate.Helpers;
using HiGeekNewsWebProject.Entites.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HiGeekNewsWebProject.Associate.DTOs
{
    public class UserDTO : BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [FileExtension]
        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        public virtual ICollection<Follow> Followers { get; set; }
        public virtual ICollection<Follow> Followings { get; set; }
    }
}
