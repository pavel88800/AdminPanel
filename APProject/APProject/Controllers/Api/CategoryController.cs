namespace APProject.Controllers.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.BL.Interfaces;
    using APProject.Controllers.Base;
    using Microsoft.AspNetCore.Mvc;

    public class CategoryController : BaseApiController
    {
        private readonly ICategoryService _categoryService;

        /// <summary>
        ///     Контроллер.
        /// </summary>
        /// <param name="categoryService"></param>
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        ///     Получить все категории.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetArticles(int offset, int count)
        {
            var result = await _categoryService.GetCategoriesAsync(offset, count);
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
            var result = await _categoryService.GetCategoryById(id);
            return Ok(result);
        }

        /// <summary>
        ///     Создать новую категорию.
        /// </summary>
        /// <param name="categoryDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddArticle([FromForm]CategoryDto categoryDto)
        {
            var result = await _categoryService.AddCategory(categoryDto);
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
            var result = _categoryService.DeleteCategory(ids);
            return Ok(result);
        }

        /// <summary>
        ///     Обновить категорию.
        /// </summary>
        /// <param name="categoryDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateReview([FromForm]CategoryDto categoryDto)
        {
            var result = _categoryService.UpdateCategory(categoryDto);
            return Ok(result);
        }
    }
}