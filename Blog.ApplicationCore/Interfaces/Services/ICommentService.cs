using Blog.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ApplicationCore.Interfaces.Repositories
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDTO>> GetComments(int count = 5);
        Task<string> AddComment(AddCommentDTO comment);
        Task RemoveComment(string id);
    }
}
