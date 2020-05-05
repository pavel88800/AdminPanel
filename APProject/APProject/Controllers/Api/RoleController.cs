namespace APProject.Controllers.Api
{
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.BL.Interfaces;
    using APProject.Controllers.Base;
    using Microsoft.AspNetCore.Mvc;

    public class RoleController : BaseApiAuthController
    {
        private readonly IRoleService _roleService;

        /// <summary>
        ///     Контроллер.
        /// </summary>
        /// <param name="reviewService"></param>
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        ///     Получить все роль.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetRoles(int offset, int count)
        {
            var result = await _roleService.GetRoles(offset, count);
            return result.Entities;
        }

        /// <summary>
        ///     Получить роль по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetRoleById(long id)
        {
            var result = await _roleService.GetRole(id);
            return Ok(result);
        }

        /// <summary>
        ///     Создать новую роль.
        /// </summary>
        /// <param name="reviewDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleDto dto)
        {
            var result = await _roleService.CreateRole(dto);
            return Ok(result);
        }

        /// <summary>
        ///     Удалить роли по идентификатору.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteRoles(long[] ids)
        {
            var result = _roleService.DeleteRole(ids);
            return Ok(result);
        }

        /// <summary>
        ///     Обновить роль .
        /// </summary>
        /// <param name="reviewDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateRole(RoleDto dto)
        {
            var result = _roleService.UpdateRole(dto);
            return Ok(result);
        }
    }
}