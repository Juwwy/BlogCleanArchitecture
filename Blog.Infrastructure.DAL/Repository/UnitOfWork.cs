using Blog.ApplicationCore.Entities;
using Blog.ApplicationCore.Interfaces.Repositories;
using Blog.Infrastructure.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext DbContext;
        public IRepository<Article> Articles { get; private set; }

        public IRepository<Comment> Comments { get; private set; }

        public IRepository<Category> Categories { get; private set; }
        public UnitOfWork(IRepository<Article> articleRepository, IRepository<Category> categoryRepository, IRepository<Comment> commentRepository, BlogDbContext dbContext)
        {
            Articles = articleRepository;
            Categories = categoryRepository;
            Comments = commentRepository;
            DbContext = dbContext;
        }
       

        public async Task<int> Complete()
        {
            return await DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
