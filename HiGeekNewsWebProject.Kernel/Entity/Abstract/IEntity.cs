using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Kernel.Entity.Abstract
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
