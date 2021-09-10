using Blog.ApplicationCore.DTOs;
using Blog.ApplicationCore.Entities;
using Blog.ApplicationCore.Interfaces;
using Blog.ApplicationCore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ApplicationCore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly string[] includes = new string[] { };

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> AddCategory(CategoryDTO model)
        {
            var category = new Category
            {

                Name = model.Name,
                ImageUrl = model.ImageUrl
            };
            await unitOfWork.Categories.Add(category);
            await unitOfWork.Complete();
            return category.Id;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories(int count = 20)
        {
            var categories = await unitOfWork.Categories.GetAll(includes);
            return categories.Select(a => Map(a)).ToList();
        }

        public async Task<CategoryDTO> GetCategory(string id)
        {
            return Map(await unitOfWork.Categories.Find(id));
        }

        public async Task RemoveCategory(string id)
        {
            var category = await unitOfWork.Categories.Find(id);

            unitOfWork.Categories.Remove(category);
        }

        private static CategoryDTO Map(Category model)
        {
            return new CategoryDTO
            {
                Id = model.Id,
                Name = model.Name,
                ImageUrl = model.ImageUrl
            };
        }
    }
}
