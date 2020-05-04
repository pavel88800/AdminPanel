namespace APP.Auth.Interfaces
{
    using System.Security.Claims;

    /// <summary>
    ///     Интрефейс для работы с токеном.
    /// </summary>
    public interface IGenerateTokenService
    {
        /// <summary>
        ///     Сгенерировать и отдать токен.
        /// </summary>
        /// <param name="login">логин.</param>
        /// <param name="password"> пароль.</param>
        /// <returns></returns>
        object GetToken(string login, string password);
    }
}