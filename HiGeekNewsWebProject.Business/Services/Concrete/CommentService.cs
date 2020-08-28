using AutoMapper;
using HiGeekNewsWebProject.Associate.DTOs;
using HiGeekNewsWebProject.Business.Services.Abstract;
using HiGeekNewsWebProject.Business.UnitOfWork.Abstract;
using HiGeekNewsWebProject.Entites.Entity;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiGeekNewsWebProject.Business.Services.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public void Add(CommentDTO model)
        {
            Comment comment = new Comment();
            var commentObj = _mapper.Map<Comment>(model);
            _unitOfWork.Comment.Add(commentObj);
            _unitOfWork.SaveChange();
        }

        public void Delete(Guid id)
        {
            var comment = _unitOfWork.Comment.GetById(id);

            if (comment != null)
            {
                _unitOfWork.Comment.Delete(comment);
                _unitOfWork.SaveChange();
            }
        }

        public CommentDTO Get(Guid id)
        {
            var comment = _unitOfWork.Comment.GetById(id);
            CommentDTO commentDTO = new CommentDTO();
            commentDTO.InjectFrom(comment);
            return commentDTO;
        }

        public IList<CommentDTO> GetAll()
        {
            var comment = _unitOfWork.Comment.GetAll();
            var model = _mapper.Map<IList<CommentDTO>>(comment);
            return model;
        }

        public IList<CommentDTO> GetByPost(Guid id)
        {
            var comment = _unitOfWork.Comment.FindByList(x => x.PostId == id).OrderByDescending(x => x.CreateDate).Take(5);
            var model = _mapper.Map<IList<CommentDTO>>(comment);
            return model;
        }

        public IList<CommentDTO> GetByUser(Guid id)
        {
            var comment = _unitOfWork.Comment.FindByList(x => x.UserId == id);
            var model = _mapper.Map<IList<CommentDTO>>(comment);
            return model;
        }
    }
}
