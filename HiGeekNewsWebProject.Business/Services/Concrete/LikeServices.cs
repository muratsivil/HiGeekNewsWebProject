using HiGeekNewsWebProject.Associate.VMs;
using HiGeekNewsWebProject.Business.Services.Abstract;
using HiGeekNewsWebProject.Business.UnitOfWork.Abstract;
using HiGeekNewsWebProject.Entites.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HiGeekNewsWebProject.Business.Services.Concrete
{
    public class LikeServices : ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LikeServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public JsonLikeVM Like(Guid id, string userName)
        {
            JsonLikeVM js = new JsonLikeVM();
            Post post = _unitOfWork.Post.GetById(id);
            AppUser user = _unitOfWork.User.Find(x => x.UserName == userName);

            if (post != null)
            {
                if (!(_unitOfWork.Like.Any(x => x.UserId.ToString() == user.Id && x.PostId == id)))
                {
                    Like like = new Like();
                    like.PostId = post.Id;
                    like.UserId = Guid.Parse(user.Id);
                    _unitOfWork.Like.Add(like);
                    _unitOfWork.SaveChange();

                    js.Likes = _unitOfWork.Like.FindByList(x => x.PostId == post.Id).Count();
                    return js;
                }
                else
                {
                    Like like = _unitOfWork.Like.Find(x => x.PostId == post.Id && x.UserId.ToString() == user.Id);
                    _unitOfWork.Like.Delete(like);
                    _unitOfWork.SaveChange();
                    js.Likes = _unitOfWork.Like.FindByList(x => x.PostId == post.Id).Count();
                    return js;
                }
            }
            else
            {
                js.Likes = 0;
                return js;
            }
        }
    }
}
