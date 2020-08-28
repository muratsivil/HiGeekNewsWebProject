using HiGeekNewsWebProject.Associate.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Business.Services.Abstract
{
    public interface ICommentService
    {
        void Add(CommentDTO model);
        void Delete(Guid id);

        IList<CommentDTO> GetAll();
        IList<CommentDTO> GetByPost(Guid id);
        IList<CommentDTO> GetByUser(Guid id);

        CommentDTO Get(Guid id);
    }
}
