using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HiGeekNewsWebProject.Kernel.Repository.Abstract
{
    public interface IKernelRepository<T>
    {
        bool Any(Expression<Func<T, bool>> exp);
        void Add(T item);
        void Update(T item);
        void Delete(T item);

        T GetById(Guid id);
        T Find(Expression<Func<T, bool>> exp);

        ICollection<T> GetAll();

        ICollection<T> FindByList(Expression<Func<T, bool>> exp);
    }
}
