using HiGeekNewsWebProject.Associate.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Business.Services.Abstract
{
    public interface IAppUserService
    {
        public void Add(UserDTO model);
        public void Update(UserDTO model);
        public void Delete(Guid id);

        public IList<UserDTO> GetFollowed(Guid id);
        public IList<UserDTO> GetFollower(Guid id);

        public UserDTO GetUserById(Guid Id);

        public IList<UserDTO> GetList();

        public IList<UserDTO> SearchList(string userName);

        public bool IsFollowing(string userName_1, string userName_2);
    }
}
