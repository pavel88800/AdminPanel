using System.Collections.Generic;
using System.Threading.Tasks;
using APP.BL.Dto;
using APP.BL.Interfaces;
using APProject.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace APProject.Controllers.Api
{
    public class ReviewController : BaseApiController
    {
        private readonly IReviewService _reviewService;

        /// <summary>
        ///     Контроллер.
        /// </summary>
        /// <param name="articleService"></param>
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        /// <summary>
        ///     Получить все статьи.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetArticles(int offset, int count)
        {
            var result = await _reviewService.GetReviewAsync(offset, count);
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
            var result = await _reviewService.GetReviewById(id);
            return Ok(result);
        }

        /// <summary>
        ///     Создать новую статью.
        /// </summary>
        /// <param name="articlesDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddArticle(ReviewDto reviewDto)
        {
            var result = await _reviewService.AddReview(reviewDto);
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
            var result = _reviewService.DeleteReview(ids);
            return Ok(result);
        }

        /// <summary>
        ///     Удалить статьи по идентификатору.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateReview(ReviewDto reviewDto)
        {
            var result = _reviewService.UpdateReview(reviewDto);
            return Ok(result);
        }
    }
}