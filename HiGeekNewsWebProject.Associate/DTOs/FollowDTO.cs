using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Associate.DTOs
{
    public class FollowDTO : BaseDTO
    {
        public Guid FollowerId { get; set; }
        public Guid FollowingId { get; set; }
    }
}
