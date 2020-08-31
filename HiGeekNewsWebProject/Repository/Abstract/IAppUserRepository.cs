using HiGeekNewsWebProject.Entites.Entity;
using HiGeekNewsWebProject.Kernel.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.DataAccess.Repository.Abstract
{
    public interface IAppUserRepository : IKernelRepository<AppUser>
    {
        AppUser FindByUserName(string userName);
        bool CheckCredentials(string userName, string password);
        
    }
}
