using Blog.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ApplicationCore.Interfaces.Repositories
{
    public interface IArticleService
    {
        Task<ArticleDTO> GetArticle(string id);
        Task<IEnumerable<ArticleDTO>> GetArticles(int count = 20);
        Task<IEnumerable<ArticleDTO>> GetRelatedArticles(string catId);
        Task<IEnumerable<ArticleDTO>> GetPopularArticles();
        Task RemoveArticle(string id);
        Task<string> AddArticle(ArticleDTO article);

    }
}
