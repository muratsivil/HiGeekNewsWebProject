using HiGeekNewsWebProject.Associate.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HiGeekNewsWebProject.Associate.DTOs
{
    public class PostDTO : BaseDTO
    {
        [Required]
        public string Content { get; set; }
        [FileExtension]
        public string ImagePath { get; set; }
        public Guid UserId { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
