using Blog.ApplicationCore.DTOs;
using Blog.ApplicationCore.Interfaces;
using Blog.Presentation.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Presentation.API.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: response to api/v1/category
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await categoryService.GetAllCategories());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetASync(string id)
        {
            var category = await categoryService.GetCategory(id);
            if (category != null)
                return Ok(category);

            return NotFound();

        }

       

        //POST: respond to api/v1/category
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostAsync([FromBody] CategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ooops something went wrong");
            var category = new CategoryDTO
            {
                Name = model.CategoryName,
                ImageUrl = model.ImageUrl
            };
            var catId = await categoryService.AddCategory(category);
            if (catId != null)
                return CreatedAtAction("Get", new { Id = catId }, model);

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await categoryService.RemoveCategory(id);

            return NoContent();
        }
    }
}
