namespace APP.BL.Interfaces
{
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.DB.Models;
    using APP.Models.Results;

    /// <summary>
    ///     Сервис по работе с пользователями.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        ///     Создать пользователя.
        /// </summary>
        /// <returns></returns>
        Task<Result> CreateUser(UserDto dto);

        /// <summary>
        ///     Редактировать пользователя.
        /// </summary>
        /// <returns></returns>
        Result UpdateUser(UserDto dto);

        /// <summary>
        ///     Получить пользователей.
        /// </summary>
        /// <param name="offset">отступ.</param>
        /// <param name="count">кол-во.</param>
        /// <returns></returns>
        Task<OffsetEntitiesDto> GetUsers(int offset, int count);

        /// <summary>
        ///     Получить пользователя по идентификатору.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns></returns>
        Task<User> GetUser(long id);

        /// <summary>
        ///     Удалить пользователя.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns></returns>
        Result DeleteUser(long[] id);
    }
}