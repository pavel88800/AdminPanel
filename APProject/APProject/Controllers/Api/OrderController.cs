namespace APProject.Controllers.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.BL.Interfaces;
    using APProject.Controllers.Base;
    using Microsoft.AspNetCore.Mvc;

    public class OrderController : BaseApiController
    {
        private readonly IOrderService _orderService;

        /// <summary>
        ///     Контроллер.
        /// </summary>
        /// <param name="orderService"></param>
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        ///     Получить все заказы.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetArticles(int offset, int count)
        {
            var result = await _orderService.GetOrderAsync(offset, count);
            return result.Entities;
        }

        /// <summary>
        ///     Получить заказ по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetArtcileById(long id)
        {
            var result = await _orderService.GetOrderById(id);
            return Ok(result);
        }

        /// <summary>
        ///     Создать новый заказ.
        /// </summary>
        /// <param name="orderDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddArticle([FromForm] OrderDto orderDto)
        {
            var result = await _orderService.AddOrder(orderDto);
            return Ok(result);
        }

        /// <summary>
        ///     Удалить заказ по идентификатору.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteArticles(List<long> ids)
        {
            var result = _orderService.DeleteOrder(ids);
            return Ok(result);
        }

        /// <summary>
        ///     Обновить заказ.
        /// </summary>
        /// <param name="orderDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateOrder([FromForm] OrderDto orderDto)
        {
            var result = _orderService.UpdateOrder(orderDto);
            return Ok(result);
        }
    }
}