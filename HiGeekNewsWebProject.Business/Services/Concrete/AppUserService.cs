using AutoMapper;
using HiGeekNewsWebProject.Associate.DTOs;
using HiGeekNewsWebProject.Business.Services.Abstract;
using HiGeekNewsWebProject.Business.UnitOfWork.Abstract;
using HiGeekNewsWebProject.Business.Validation.ValueInjector;
using HiGeekNewsWebProject.Entites.Entity;
using Microsoft.AspNetCore.Hosting;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HiGeekNewsWebProject.Business.Services.Concrete
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AppUserService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._webHostEnvironment = webHostEnvironment;
        }
        public void UserCreate(RegisterDTO model)
        {
            AppUser appUser = _mapper.Map<AppUser>(model);
            _unitOfWork.User.Add(appUser);
            _unitOfWork.SaveChange();
        }
        public void Add(UserDTO model)
        {
            if (model.Image != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/user");

                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                string fileName = Path.GetFileName(model.Image.FileName);

                using (FileStream stream = new FileStream(Path.Combine(uploadDir, fileName), FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                    model.ImagePath = fileName;
                }
            }

            AppUser appUser = _mapper.Map<AppUser>(model);
            _unitOfWork.User.Add(appUser);
            _unitOfWork.SaveChange();
        }

        public void Update(UserDTO model)
        {
            if (model.Image != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/user");

                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                string fileName = Path.GetFileName(model.Image.FileName);

                using (FileStream stream = new FileStream(Path.Combine(uploadDir, fileName), FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                    model.ImagePath = fileName;
                }
            }

            AppUser appUser = _mapper.Map<AppUser>(model);
            appUser.InjectFrom<FilterId>(model);
            _unitOfWork.User.Update(appUser);
            _unitOfWork.SaveChange();
        }

        public void Delete(Guid id)
        {
            var user = _unitOfWork.User.Find(x => x.Id == id.ToString());
        }

        public IList<UserDTO> GetFollowed(Guid id)
        {
            IList<UserDTO> model = null;

            var user = _unitOfWork.User.Find(x => x.Id == id.ToString());
            var followed = _unitOfWork.Follow.FindByList(x => x.FollowingId.ToString() == user.Id);

            List<AppUser> followedList = new List<AppUser>();

            foreach (var item in followed)
            {
                followedList.AddRange(_unitOfWork.User.FindByList(x => x.Id == item.FollowerId.ToString()));
            }

            model = _mapper.Map<IList<UserDTO>>(followedList).OrderBy(x => x.UserName).ToList();

            return model;
        }

        public IList<UserDTO> GetFollower(Guid id)
        {
            IList<UserDTO> model = null;

            var user = _unitOfWork.User.Find(x => x.Id == id.ToString());
            var follower = _unitOfWork.Follow.FindByList(x => x.FollowerId.ToString() == user.Id);

            List<AppUser> followerList = new List<AppUser>();

            foreach (var item in follower)
            {
                followerList.AddRange(_unitOfWork.User.FindByList(x => x.Id == item.FollowerId.ToString()));
            }

            model = _mapper.Map<IList<UserDTO>>(followerList).OrderBy(x => x.UserName).ToList();

            return model;

        }

        public UserDTO GetUserById(Guid id)
        {
            var user = _unitOfWork.User.Find(x => x.Id == id.ToString());
            UserDTO model = _mapper.Map<UserDTO>(user);
            return model;
        }

        public IList<UserDTO> GetList()
        {
            var users = _unitOfWork.User.GetAll();
            IList<UserDTO> model = _mapper.Map<IList<UserDTO>>(users);
            return model;
        }

        public IList<UserDTO> SearchList(string userName)
        {
            IList<UserDTO> model = null;

            //Linq to SQL
            var users = from u in _unitOfWork.User.GetAll() select u;

            if (!String.IsNullOrWhiteSpace(userName))
            {
                users = users.Where(x => x.UserName.Contains(userName)).OrderBy(x => x.UserName).ToList();
            }

            model = _mapper.Map<IList<UserDTO>>(users);
            return model;
        }

        public bool IsFollowing(string userName_1, string userName_2)
        {
            var user_1 = _unitOfWork.User.Find(x => x.UserName == userName_1);
            var user_2 = _unitOfWork.User.Find(x => x.UserName == userName_2);

            var follower = _unitOfWork.Follow.FindByList(x => x.FollowingId.ToString() == user_1.Id);

            if (follower.Any(x => x.FollowingId.ToString() == user_2.Id))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
