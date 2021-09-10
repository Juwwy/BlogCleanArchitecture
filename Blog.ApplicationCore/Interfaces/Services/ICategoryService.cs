using Blog.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ApplicationCore.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetCategory(string id);
        Task<IEnumerable<CategoryDTO>> GetAllCategories(int count = 20);
        Task<string> AddCategory(CategoryDTO category);
        Task RemoveCategory(string id);
    }
}
