using HiGeekNewsWebProject.Associate.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Business.Services.Abstract
{
    public interface IPostService
    {
        public void Add(PostDTO model);
        public void Update(PostDTO model);
        public void Delete(Guid id);

        public PostDTO Get(Guid id);
        public IList<PostDTO> GetPostByUser(Guid userId);
        public IList<PostDTO> GetPosts();
        public IList<PostDTO> GetPostsByDate(DateTime startedDate, DateTime endDate);
    }
}
