using Blog.ApplicationCore.DTOs;
using Blog.ApplicationCore.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Presentation.API.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService articleService;

        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        // GET api/v1/article
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetArticle()
        {
            return Ok(await articleService.GetArticles());
        }

        // GET api/v1/article/abcd-asas-asas
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var article = await articleService.GetArticle(id);
            if (article != null)
                return Ok(article);

            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] ArticleDTO article)
        {
            var result = await articleService.AddArticle(article);
            if (result != null)
                return CreatedAtAction("GetArticle", new { Id = result }, article);

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await articleService.RemoveArticle(id);

            return NoContent();
        }

    }
}
