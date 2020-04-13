using System.Collections.Generic;
using System.Threading.Tasks;
using APP.BL.Dto;
using APP.BL.Interfaces;
using APProject.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace APProject.Controllers.Api
{
    public class BlogArticlesController : BaseApiController
    {
        private readonly IBlogArticleService _blogArticleService;

        /// <summary>
        ///     Контроллер.
        /// </summary>
        /// <param name="articleService"></param>
        public BlogArticlesController(IBlogArticleService blogArticleService)
        {
            _blogArticleService = blogArticleService;
        }

        /// <summary>
        ///     Получить все статьи.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetBlogArticleAsync(int offset, int count)
        {
            var result = await _blogArticleService.GetBlogArticleAsync(offset, count);
            return result.Entities;
        }

        /// <summary>
        ///     Получить статью по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetBlogArticleById(long id)
        {
            var result = await _blogArticleService.GetBlogArticleById(id);
            return Ok(result.Entities);
        }

        /// <summary>
        ///     Создать новую статью.
        /// </summary>
        /// <param name="articlesDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddBlogArticle([FromForm]BlogArticlesDto articlesDto)
        {
            var result = await _blogArticleService.AddBlogArticle(articlesDto);
            return Ok(result);
        }

        /// <summary>
        ///     Удалить статьи по идентификатору.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteBlogArticle(List<long> ids)
        {
            var result = _blogArticleService.DeleteBlogArticle(ids);
            return Ok(result);
        }
    }
}