namespace APP.BL.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.BL.Interfaces;
    using APP.DB;
    using APP.DB.Models;
    using APP.Models.Results;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    ///     Сервис по работе с ролями.
    /// </summary>
    public class RoleService : AbstractGetService<Role>, IRoleService
    {
        private readonly PanelContext _context;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="context">Контекст БД.</param>
        public RoleService(PanelContext context) : base(context)
        {
            _context = context;
        }

        ///<inheritdoc />
        public async Task<Result> CreateRole(RoleDto dto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var users = await _context.Users
                    .Where(x => dto.UsersId.Contains(x.Id))
                    .ToListAsync();

                var role = new Role
                {
                    Name = dto.Name,
                    Sort = dto.Sort,
                    Status = dto.Status,
                    Users = users ?? null
                };

                _context.Add(role);
                _context.SaveChanges();

                transaction.Commit();

                return Result.Ok();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ApplicationException(e.InnerException.Message ?? e.Message);
            }
        }

        ///<inheritdoc />
        public Result UpdateRole(RoleDto dto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var users = _context.Users
                    .Where(x => dto.UsersId.Contains(x.Id))
                    .ToList();

                var role = _context.Roles.Find(dto.Id);

                if (role != null)
                {
                    role.Name = dto.Name;
                    role.Sort = dto.Sort;
                    role.Status = dto.Status;
                    role.Users = users ?? null;

                    _context.Update(role);
                }

                _context.SaveChanges();

                transaction.Commit();

                return Result.Ok();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ApplicationException(e.InnerException.Message ?? e.Message);
            }
        }

        ///<inheritdoc />
        public async Task<OffsetEntitiesDto> GetRoles(int offset, int count)
        {
            return await GetPagesAsync(offset, count);
        }

        ///<inheritdoc />
        public async Task<Role> GetRole(long id)
        {
            return await GetItemById(id);
        }

        ///<inheritdoc />
        public Result DeleteRole(long[] id)
        {
            try
            {
                DeleteItems(id);
                return Result.Ok();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.InnerException.Message ?? e.Message);
            }
        }
    }
}