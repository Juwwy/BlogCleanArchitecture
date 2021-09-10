using Blog.ApplicationCore.Interfaces;
using Blog.ApplicationCore.Interfaces.Repositories;
using Blog.ApplicationCore.Interfaces.Services;
using Blog.ApplicationCore.Services;
using Blog.Infrastructure.DAL.DBContext;
using Blog.Infrastructure.DAL.Repository;
using Blog.Infrastructure.DAL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.IoC
{
    public static class BlogDependencyContainer
    {
        public static IServiceCollection AddBlogServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
