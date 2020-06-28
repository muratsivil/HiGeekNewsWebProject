using HiGeekNewsWebProject.Kernel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Kernel.Entity.Concrete
{
    public class KernelEntity
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }
        public string CreatedIp { get; set; }


        public DateTime? ModifiedDate { get; set; }
        public string ModifiedIp { get; set; }
        public string ModifiedBy { get; set; }

        public Status Status { get; set; }
    }
}
