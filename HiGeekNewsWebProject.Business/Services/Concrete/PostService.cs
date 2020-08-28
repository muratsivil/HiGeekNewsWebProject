using AutoMapper;
using HiGeekNewsWebProject.Associate.DTOs;
using HiGeekNewsWebProject.Business.Services.Abstract;
using HiGeekNewsWebProject.Business.UnitOfWork.Abstract;
using HiGeekNewsWebProject.Entites.Entity;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HiGeekNewsWebProject.Business.Services.Concrete
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PostService(IMapper mapper, IUnitOfWork unitofWork, IWebHostEnvironment hostEnvironment)
        {
            this._mapper = mapper;
            this._unitofWork = unitofWork;
            this._hostEnvironment = hostEnvironment;
        }

        public void Add(PostDTO model)
        {
            var user = _unitofWork.User.Find(x => x.Id == model.UserId.ToString());

            if (model.Image != null)
            {
                string uploadDir = Path.Combine(_hostEnvironment.WebRootPath, "media/post");

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

            Post postObj = _mapper.Map<Post>(model);
            _unitofWork.Post.Add(postObj);
            _unitofWork.SaveChange();
        }

        public void Delete(Guid id)
        {
            Post postObj = _unitofWork.Post.GetById(id);

            if (postObj != null)
            {
                _unitofWork.Post.Delete(postObj);
                _unitofWork.SaveChange();
            }
        }

        public PostDTO Get(Guid id)
        {
            Post postObj = _unitofWork.Post.GetById(id);

            try
            {
                PostDTO model = _mapper.Map<PostDTO>(postObj);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public IList<PostDTO> GetPostByUser(Guid userId)
        {
            var post = _unitofWork.Post.FindByList(x => x.UserId == userId).OrderByDescending(x => x.CreateDate);

            IList<PostDTO> model = _mapper.Map<IList<PostDTO>>(post);

            return model;
        }

        public IList<PostDTO> GetPosts()
        {
            var posts = _unitofWork.Post.GetAll().OrderByDescending(x => x.CreateDate);

            IList<PostDTO> model = _mapper.Map<IList<PostDTO>>(posts);

            return model;
        }

        public IList<PostDTO> GetPostsByDate(DateTime startedDate, DateTime endDate)
        {
            var posts = _unitofWork.Post.FindByList(x => x.CreateDate == startedDate && x.CreateDate == endDate);

            IList<PostDTO> model = _mapper.Map<IList<PostDTO>>(posts);

            return model;
        }

        public void Update(PostDTO model)
        {
            var user = _unitofWork.User.Find(x => x.Id == model.UserId.ToString());

            if (model.Image != null)
            {
                string uploadDir = Path.Combine(_hostEnvironment.WebRootPath, "media/post");

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

            Post postObj = _mapper.Map<Post>(model);
            _unitofWork.Post.Update(postObj);
            _unitofWork.SaveChange();
        }
    }
}
