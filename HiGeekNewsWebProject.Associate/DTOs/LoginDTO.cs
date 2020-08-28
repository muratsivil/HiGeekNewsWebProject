using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Associate.DTOs
{
    public class LoginDTO : BaseDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
