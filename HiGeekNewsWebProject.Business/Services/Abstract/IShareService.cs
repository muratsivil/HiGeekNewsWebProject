using HiGeekNewsWebProject.Associate.VMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Business.Services.Abstract
{
    public interface IShareService
    {
        JsonShareVM MakeShare(Guid id, string userName);
    }
}
