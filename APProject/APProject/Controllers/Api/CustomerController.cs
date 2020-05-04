using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP.BL.Dto;
using APP.BL.Interfaces;
using APProject.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace APProject.Controllers.Api
{
    public class CustomerController : BaseApiAuthController
    {
        private readonly ICustomerService _customerService;

        /// <summary>
        ///     Контроллер.
        /// </summary>
        /// <param name="blogCategoryService"></param>
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        ///     Получить все отзывы блога.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetArticles(int offset, int count)
        {
            var result = await _customerService.GetCustomerAsync(offset, count);
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
            var result = await _customerService.GetCustomerById(id);
            return Ok(result);
        }

        /// <summary>
        ///     Создать новый отзыв.
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddArticle([FromForm] CustomerDto customerDto)
        {
            var result = await _customerService.AddCustomer(customerDto);
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
            var result = _customerService.DeleteCustomer(ids);
            return Ok(result);
        }

        /// <summary>
        ///     Обновить отзыв.
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateCustomer([FromForm] CustomerDto customerDto)
        {
            var result = _customerService.UpdateCustomer(customerDto);
            return Ok(result);
        }
    }
}
