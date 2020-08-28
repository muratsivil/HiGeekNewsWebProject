using HiGeekNewsWebProject.DataAccess.Context;
using HiGeekNewsWebProject.DataAccess.Repository.Abstract;
using HiGeekNewsWebProject.DataAccess.Repository.KernelRepository.Concrete;
using HiGeekNewsWebProject.Entites.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.DataAccess.Repository.Concrete
{
    public class EfPostRepository : EfKernelRepository<Post>, IPostRepository 
    {
        public EfPostRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
