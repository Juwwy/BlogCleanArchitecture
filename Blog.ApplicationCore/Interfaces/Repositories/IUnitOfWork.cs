using Blog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ApplicationCore.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Article> Articles { get; }
        public IRepository<Comment> Comments { get; }
        public IRepository<Category> Categories { get; }
        Task<int> Complete();
    }
}
