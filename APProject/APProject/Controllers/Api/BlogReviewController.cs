using System.Collections.Generic;
using System.Threading.Tasks;
using APP.BL.Dto;
using APP.BL.Interfaces;
using APProject.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace APProject.Controllers.Api
{
    public class BlogReviewController : BaseApiController
    {
        private readonly IBlogRewiewService _blogRewiewService;

        /// <summary>
        ///     Контроллер.
        /// </summary>
        /// <param name="blogCategoryService"></param>
        public BlogReviewController(IBlogRewiewService blogRewiewService)
        {
            _blogRewiewService = blogRewiewService;
        }

        /// <summary>
        ///     Получить все отзывы блога.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetArticles(int offset, int count)
        {
            var result = await _blogRewiewService.GetBlogRewiewAsync(offset, count);
            return result.Entities;
        }

        /// <summary>
        ///     Получить отзыв блога по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetArtcileById(long id)
        {
            var result = await _blogRewiewService.GetBlogRewiewById(id);
            return Ok(result);
        }

        /// <summary>
        ///     Создать новый отзыв.
        /// </summary>
        /// <param name="rewiewDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddArticle([FromForm] BlogRewiewDto rewiewDto)
        {
            var result = await _blogRewiewService.AddBlogRewiew(rewiewDto);
            return Ok(result);
        }

        /// <summary>
        ///     Удалить отзыв по идентификатору.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteArticles(List<long> ids)
        {
            var result = _blogRewiewService.DeleteBlogRewiew(ids);
            return Ok(result);
        }

        /// <summary>
        ///     Обновить отзыв.
        /// </summary>
        /// <param name="rewiewDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateReview([FromForm] BlogRewiewDto rewiewDto)
        {
            var result = _blogRewiewService.UpdateBlogRewiew(rewiewDto);
            return Ok(result);
        }
    }
}