using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace HiGeekNewsWebProject.Associate.Helpers
{
    public class FileExtension : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);

                string[] extensions = { ".jpg", ".png", ".jpeg" };
                bool result = extension.Any(x => extension.EndsWith(x));

                if (!result)
                {
                    return new ValidationResult("Alowed extension are .jpg, .png, and .jpeg");
                }
            }

            return base.IsValid(value, validationContext);
        }
    }
}
