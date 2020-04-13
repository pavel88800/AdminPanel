using Newtonsoft.Json;

namespace APP.Models.Results
{
    /// <summary>
    ///     Статический класс для выдачи результата.
    /// </summary>
    /// <typeparam name="T">Передаваемая сущность.</typeparam>
    public class Result
    {
        protected Result(bool success, string error)
        {
            Success = success;
            Error = error;
        }

        /// <summary>
        ///     Успешно.
        /// </summary>
        [JsonProperty("success")]
        public static bool Success { get; private set; }

        /// <summary>
        ///     Ошибка.
        /// </summary>
        [JsonProperty("error")]
        public static string Error { get; private set; }

        /// <summary>
        ///     Успешный ответ.
        /// </summary>
        /// <param name="ent">Передаваемая сущность.</param>
        /// <returns></returns>
        public static Result Ok()
        {
            return new Result(true, string.Empty);
        }

        /// <summary>
        ///     Успешный ответ.
        /// </summary>
        /// <param name="ent">Передаваемая сущность.</param>
        /// <returns></returns>
        public static Result<T> Ok<T>(T ent)
        {
            return new Result<T>(ent, true, string.Empty);
        }

        /// <summary>
        ///     Не успешный ответ.
        /// </summary>
        /// <param name="exp">Текст ошибки.</param>
        /// <returns></returns>
        public static Result Fail(string exp)
        {
            return new Result(false, exp);
        }

        /// <summary>
        ///     Не успешный ответ.
        /// </summary>
        /// <param name="value">Передаваемая сущность.</param>
        /// <param name="exp">Текст ошибки.</param>
        /// <returns></returns>
        public static Result<T> Fail<T>(T value, string exp)
        {
            return new Result<T>(value, false, exp);
        }
    }

    public class Result<T> : Result
    {
        public Result(T value, bool success, string error) : base(success, error)
        {
            Value = value;
        }

        [JsonProperty("value")] public T Value { get; private set; }
    }
}