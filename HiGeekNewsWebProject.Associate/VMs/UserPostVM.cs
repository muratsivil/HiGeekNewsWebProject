using HiGeekNewsWebProject.Associate.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Associate.VMs
{
    public class UserPostVm
    {
        public UserPostVm()
        {
            Posts = new List<PostDTO>();
            Comments = new List<CommentDTO>();
        }

        public List<PostDTO> Posts { get; set; }
        public List<CommentDTO> Comments { get; set; }
        public PostDTO PostDTO { get; set; }
    }
}
