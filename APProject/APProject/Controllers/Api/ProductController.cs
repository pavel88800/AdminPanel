using System.Collections.Generic;
using System.Threading.Tasks;
using APP.BL.Dto;
using APP.BL.Interfaces;
using APProject.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace APProject.Controllers.Api
{
    public class ProductController : BaseApiAuthController
    {
        private readonly IProductService _productService;

        /// <summary>
        ///     Контроллер.
        /// </summary>
        /// <param name="articleService"></param>
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        ///     Получить все статьи.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetProduct(int offset, int count)
        {
            var result = await _productService.GetProductAsync(offset, count);
            return result.Entities;
        }

        /// <summary>
        ///     Получить статью по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetProductById(long id)
        {
            var result = await _productService.GetProductById(id);
            return Ok(result);
        }

        /// <summary>
        ///     Создать новую статью.
        /// </summary>
        /// <param name="articlesDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm]ProductDto productDto)
        {
            var result = await _productService.AddProduct(productDto);
            return Ok(result);
        }

        /// <summary>
        ///     Удалить статьи по идентификатору.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteProduct(List<long> ids)
        {
            var result = _productService.DeleteProduct(ids);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromForm]ProductDto productDto)
        {
            var res = _productService.UpdateProduct(productDto);
            return Ok(res);
        }
    }
}