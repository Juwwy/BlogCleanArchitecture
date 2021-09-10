using Blog.ApplicationCore.DTOs;
using Blog.ApplicationCore.Entities;
using Blog.ApplicationCore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ApplicationCore.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly string[] includes = new string[] { "Commentator"};

        public CommentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> AddComment(AddCommentDTO model)
        {
            var comment = new Comment()
            {
                Content = model.Content,
                ArticleId = model.ArticleId,
                CommentatorId = model.CommentId
            };

            var article = await unitOfWork.Articles.Find(model.ArticleId);
            article.NumberOfComments++;
            unitOfWork.Articles.Update(article);

            await unitOfWork.Comments.Add(comment);
            await unitOfWork.Complete();

            return comment.Id;
        }

        public async Task<IEnumerable<CommentDTO>> GetComments(int count = 5)
        {
            var comments = await unitOfWork.Comments.GetAll(includes, 5);

            return comments.Select(c => new CommentDTO
            {
                Id = c.Id,
                Content = c.Content,
                CommentatorName = $"{c.Commentator.Firstname} {c.Commentator.Lastname}",
                DateCreated = c.DateCreated.ToString("D")
            }).ToList();
        }

        public async Task RemoveComment(string id)
        {
            var comment = await unitOfWork.Comments.Find(id);
            unitOfWork.Comments.Remove(comment);
        }

       
    }
}
