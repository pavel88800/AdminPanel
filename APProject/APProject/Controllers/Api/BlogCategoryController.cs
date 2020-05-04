namespace APProject.Controllers.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.BL.Interfaces;
    using APProject.Controllers.Base;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Контроллер по работе с категориями блога.
    /// </summary>
    public class BlogCategoryController : BaseApiAuthController
    {
        private readonly IBlogCategoryService _blogCategoryService;

        /// <summary>
        ///     Контроллер.
        /// </summary>
        /// <param name="blogCategoryService"></param>
        public BlogCategoryController(IBlogCategoryService blogCategoryService)
        {
            _blogCategoryService = blogCategoryService;
        }

        /// <summary>
        ///     Получить все категории.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetArticles(int offset, int count)
        {
            var result = await _blogCategoryService.GetCategoriesAsync(offset, count);
            return result.Entities;
        }

        /// <summary>
        ///     Получить категорию по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetArtcileById(long id)
        {
            var result = await _blogCategoryService.GetCategoryById(id);
            return Ok(result);
        }

        /// <summary>
        ///     Создать новую категорию.
        /// </summary>
        /// <param name="categoryDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddArticle([FromForm] BlogCategoryDto categoryDto)
        {
            var result = await _blogCategoryService.AddCategory(categoryDto);
            return Ok(result);
        }

        /// <summary>
        ///     Удалить категорию по идентификатору.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteArticles(List<long> ids)
        {
            var result = _blogCategoryService.DeleteCategory(ids);
            return Ok(result);
        }

        /// <summary>
        ///     Обновить категорию.
        /// </summary>
        /// <param name="categoryDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateReview([FromForm] BlogCategoryDto categoryDto)
        {
            var result = _blogCategoryService.UpdateCategory(categoryDto);
            return Ok(result);
        }
    }
}