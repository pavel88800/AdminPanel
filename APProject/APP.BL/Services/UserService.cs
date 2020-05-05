using Microsoft.EntityFrameworkCore;

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

    /// <summary>
    ///     Сервис по работе с пользователями.
    /// </summary>
    public class UserService : AbstractGetService<User>, IUserService
    {
        private readonly PanelContext _context;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="context">контекст БД.</param>
        public UserService(PanelContext context) : base(context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Result> CreateUser(UserDto dto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var role = await _context.Roles.FindAsync(dto.RoleId);
                var user = new User
                {
                    Age = dto.Age,
                    City = dto.City,
                    Email = dto.Email,
                    LastName = dto.LastName,
                    Login = dto.Login,
                    Name = dto.Name,
                    Password = dto.Password,
                    Sort = dto.Sort,
                    Status = dto.Status,
                    Role = role
                };

                _context.Add(user);
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

        /// <inheritdoc />
        public Result UpdateUser(UserDto dto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var role = _context.Roles.Find(dto.RoleId);
                var user = _context.Users.FirstOrDefault(x => x.Id == dto.Id);

                if (user != null)
                {
                    user.Age = dto.Age;
                    user.City = dto.City;
                    user.Email = dto.Email;
                    user.LastName = dto.LastName;
                    user.Login = dto.Login;
                    user.Name = dto.Name;
                    user.Password = dto.Password;
                    user.Sort = dto.Sort;
                    user.Status = dto.Status;
                    user.Role = role;

                    _context.Update(user);
                    _context.SaveChanges();

                }
                
                transaction.Commit();
                return Result.Ok();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ApplicationException(e.InnerException.Message ?? e.Message);
            }
        }

        /// <inheritdoc />
        public Task<OffsetEntitiesDto> GetUsers(int offset, int count)
        {
            return GetPagesAsync(offset, count);
        }

        /// <inheritdoc />
        public async Task<User> GetUser(long id)
        {
            return await GetItemById(id);
        }

        /// <inheritdoc />
        public Result DeleteUser(long[] id)
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