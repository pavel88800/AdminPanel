using System.Threading.Tasks;
using APP.OtherApi.YouTube.Dto;
using APP.OtherApi.YouTube.Intefaces;
using APProject.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace APProject.Controllers.Api
{
    public class SearchByKeywordApiYouTubeController : BaseApiController
    {
        private readonly ISearchByKeywordService _search;

        public SearchByKeywordApiYouTubeController(ISearchByKeywordService search)
        {
            _search = search;
        }

        /// <summary>
        ///     Получить видео с Ютуба
        /// </summary>
        /// <param name="search">Что ищем</param>
        /// <param name="count">Кол-во</param>
        /// <returns></returns>
        [HttpGet("/get")]
        public async Task<IActionResult> GetVideo(string search, int count)
        {
            var result = await _search.GetFromYoutube(search, count);
            return Ok(result);
        }


        /// <summary>
        ///     Сохранить найденные видосы
        /// </summary>
        /// <param name="saveLinkVideoDto"></param>
        /// <returns></returns>
        [HttpPost("/save")]
        public async Task<IActionResult> SaveVideo(SaveLinkVideoDto saveLinkVideoDto)
        {
            var result = await _search.SaveVideo(saveLinkVideoDto);
            return Ok(result);
        }
    }
}