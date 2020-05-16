using System.Threading.Tasks;
using APP.BL.Dto;
using APP.BL.Interfaces;
using APP.Common.Helpers;
using APP.DB;
using APProject.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APProject.Controllers.Api
{
    public class UserController : BaseApiAuthController
    {
        private readonly IUserService _userService;

        /// <summary>
        ///     Контроллер.
        /// </summary>
        /// <param name="reviewService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        ///     Получить все пользователей.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetUsers(int offset, int count)
        {
            var result = await _userService.GetUsers(offset, count);
            return result.Entities;
        }

        /// <summary>
        ///     Получить пользователя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var result = await _userService.GetUser(id);
            return Ok(result);
        }

        /// <summary>
        ///     Создать нового пользователя.
        /// </summary>
        /// <param name="reviewDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto dto)
        {
           
            var result = await _userService.CreateUser(dto);
            return Ok(result);
        }

        /// <summary>
        ///     Удалить пользователей по идентификатору.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteUsers(long[] ids)
        {
            var result = _userService.DeleteUser(ids);
            return Ok(result);
        }

        /// <summary>
        ///     Обновить пользователя .
        /// </summary>
        /// <param name="reviewDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateUser(UserDto dto)
        {
            var result = _userService.UpdateUser(dto);
            return Ok(result);
        }
    }
}