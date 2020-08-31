using HiGeekNewsWebProject.DataAccess.Context;
using HiGeekNewsWebProject.DataAccess.Repository.Abstract;
using HiGeekNewsWebProject.DataAccess.Repository.KernelRepository.Concrete;
using HiGeekNewsWebProject.Entites.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.DataAccess.Repository.Concrete
{
    public class EfAppUserRepository : EfKernelRepository<AppUser>, IAppUserRepository
    {
        public EfAppUserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public bool CheckCredentials(string userName, string password)
        {
            return Any(x => x.UserName == userName && x.PasswordHash == password);
        }

        public AppUser FindByUserName(string userName)
        {
            return Find(x => x.UserName == userName);
        }
    }
}
