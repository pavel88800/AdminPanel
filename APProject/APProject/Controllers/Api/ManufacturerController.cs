namespace APProject.Controllers.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.BL.Interfaces;
    using APProject.Controllers.Base;
    using Microsoft.AspNetCore.Mvc;

    public class ManufacturerController : BaseApiAuthController
    {
        /// <summary>
        ///     Сервис по работе с производителями.
        /// </summary>
        private readonly IManufacturerService _manufacturerService;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="manufacturerService">Сервис по работе с производителями.</param>
        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        /// <summary>
        ///     Получить всех производителей.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetArticles(int offset, int count)
        {
            var result = await _manufacturerService.GetManufacturerAsync(offset, count);
            return result.Entities;
        }

        /// <summary>
        ///     Получить производиителя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetArtcileById(long id)
        {
            var result = await _manufacturerService.GetManufacturerById(id);
            return Ok(result);
        }

        /// <summary>
        ///     Создать нового производителя.
        /// </summary>
        /// <param name="manufacturerDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddArticle(ManufacturerDto manufacturerDto)
        {
            var result = await _manufacturerService.AddManufacturer(manufacturerDto);
            return Ok(result);
        }

        /// <summary>
        ///     Удалить производителей по идентификатору.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteArticles(List<long> ids)
        {
            var result = _manufacturerService.DeleteManufacturer(ids);
            return Ok(result);
        }

        /// <summary>
        ///     Обновить производителя
        /// </summary>
        /// <param name="manufacturerDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateManufucturer(ManufacturerDto manufacturerDto)
        {
            var result = _manufacturerService.UpdateManufucturer(manufacturerDto);
            return Ok(result);
        }
    }
}