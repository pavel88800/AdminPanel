using System.Collections.Generic;
using System.Threading.Tasks;
using APP.Models.Results;
using APP.OtherApi.YouTube.Dto;

namespace APP.OtherApi.YouTube.Intefaces
{
    public interface ISearchByKeywordService
    {
        /// <summary>
        ///     Получить видео из Ютуба.
        /// </summary>
        /// <param name="search">что ищем.</param>
        /// <param name="count">кол-во</param>
        /// <returns></returns>
        Task<IEnumerable<SearchByKeywordServiceDto>> GetFromYoutube(string search, int count);

        /// <summary>
        /// Сохранить ссылку на видео в нашей БД.
        /// </summary>
        /// <returns></returns>
        Task<Result> SaveVideo(SaveLinkVideoDto saveLinkVideoDto);
    }
}