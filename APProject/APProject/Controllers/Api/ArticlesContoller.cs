using System.Collections.Generic;
using System.Threading.Tasks;
using APP.BL.Dto;
using APP.BL.Interfaces;
using APProject.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace APProject.Controllers.Api
{
    /// <summary>
    ///     Контроллер Статей.
    /// </summary>
    public class ArticlesContoller : BaseApiAuthController
    {
        private readonly IArticleService _articleService;

        /// <summary>
        ///     Контроллер.
        /// </summary>
        /// <param name="articleService"></param>
        public ArticlesContoller(IArticleService articleService)
        {
            _articleService = articleService;
        }

        /// <summary>
        ///     Получить все статьи.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetArticles(int offset, int count)
        {
            var result = await _articleService.GetArticlesAsync(offset, count);
            return result.Entities;
        }

        /// <summary>
        ///     Получить статью по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetArtcileById(long id)
        {
            var result = await _articleService.GetArtcileById(id);
            return Ok(result);
        }

        /// <summary>
        ///     Создать новую статью.
        /// </summary>
        /// <param name="articlesDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddArticle(ArticlesDto articlesDto)
        {
           var result = await _articleService.AddArticle(articlesDto);
            return Ok(result);
        }

        /// <summary>
        ///     Удалить статьи по идентификатору.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteArticles(List<long> ids)
        {
            var result =_articleService.DeleteArticles(ids);
            return Ok(result);
        }

        /// <summary>
        ///     Обновить статью .
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateArticles(ArticlesDto articlesDto)
        {
            var result = _articleService.UpdateArticle(articlesDto);
            return Ok(result);
        }
    }
}