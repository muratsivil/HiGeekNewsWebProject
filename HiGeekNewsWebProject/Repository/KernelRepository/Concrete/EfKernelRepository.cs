using HiGeekNewsWebProject.DataAccess.Context;
using HiGeekNewsWebProject.Kernel.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HiGeekNewsWebProject.DataAccess.Repository.KernelRepository.Concrete
{
    public class EfKernelRepository<T> : IKernelRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<T> table;

        public EfKernelRepository(ApplicationDbContext context)
        {
            this._context = context;
            this.table = _context.Set<T>();
        }
        public void Add(T item)
        {
            table.Add(item);
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return table.Any(exp);
        }

        public void Delete(T item)
        {
            table.Remove(item);
        }

        public T Find(Expression<Func<T, bool>> exp)
        {
            return table.Where(exp).FirstOrDefault();
        }

        public ICollection<T> FindByList(Expression<Func<T, bool>> exp)
        {
            return table.Where(exp).ToList();
        }

        public ICollection<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(Guid id)
        {
            return table.Find(id);
        }


        public void Update(T item)
        {
            table.Update(item);
        }
    }
}
