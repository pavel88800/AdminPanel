namespace APP.BL.Interfaces
{
    using System.Collections.Generic;
    using APP.BL.Dto;
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
        Result CreateUser(UserDto dto);

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
        List<UserDto> GetUsers(int offset, int count);

        /// <summary>
        ///     Получить пользователя по идентификатору.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns></returns>
        UserDto GetUser(long id);

        /// <summary>
        ///     Удалить пользователя.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns></returns>
        Result DeleteUser(long id);
    }
}