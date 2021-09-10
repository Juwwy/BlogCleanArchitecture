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
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly string[] includes = new string[] { "Author", "Category" };
        public ArticleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> AddArticle(ArticleDTO model)
        {
            var article = new Article
            {
                Title = model.Title,
                Content = model.Content,
                AuthorId = model.AuthorId,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl
            };
            await unitOfWork.Articles.Add(article);
            await unitOfWork.Complete();
            return article.Id;
        }

        public async Task<ArticleDTO> GetArticle(string id)
        {
            return Map(await unitOfWork.Articles.Get(a => a.Id == id, includes));
        }

        public async Task<IEnumerable<ArticleDTO>> GetArticles(int count = 20)
        {
            var articles = await unitOfWork.Articles.GetAll(includes);
            return articles.Select(a => Map(a)).ToList();
        }

        public async Task<IEnumerable<ArticleDTO>> GetPopularArticles()
        {
            var popularArticles = await unitOfWork.Articles.GetAll(a => a.NumberOfComments >= 5, includes);

            return popularArticles.Select(a => Map(a)).ToList();
        }

        public async Task<IEnumerable<ArticleDTO>> GetRelatedArticles(string catId)
        {
            var articles = await unitOfWork.Articles.GetAll(a => a.CategoryId == catId, includes);
            return articles.Select(a => Map(a)).ToList();
        }

        public async Task RemoveArticle(string id)
        {
            var article = await unitOfWork.Articles.Find(id);
             unitOfWork.Articles.Remove(article);
        }


        private static ArticleDTO Map(Article model)
        {
            return new ArticleDTO
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content,
                Author = $"{model.Author.Firstname} {model.Author.Lastname}",
                Category = model.Category.Name,
                ImageUrl = model.ImageUrl,
                NumberOfComments = model.NumberOfComments
            };
        }
    }
}
