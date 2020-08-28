using HiGeekNewsWebProject.DataAccess.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Business.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository Post { get; }
        ICommentRepository Comment { get; }
        ILikeRepository Like { get; }
        IShareRepository Share { get; }
        IAppUserRepository User { get; }
        IFollowRepository Follow { get; }
        void SaveChange();
    }
}
