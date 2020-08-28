using HiGeekNewsWebProject.Kernel.Entity.Abstract;
using HiGeekNewsWebProject.Kernel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Kernel.Entity.Concrete
{
    public class KernelEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIp { get; set; }
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedIp { get; set; }
        public string ModifiedBy { get; set; }

        public Status Status { get; set; }
    }
}
