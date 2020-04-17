using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP.DB;
using APP.DB.Models;
using APP.Models.Results;
using APP.OtherApi.YouTube.Dto;
using APP.OtherApi.YouTube.Intefaces;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace APP.OtherApi.YouTube.Services
{
    public class SearchByKeywordService : ISearchByKeywordService
    {
        /// <summary>
        ///     Ссылка на видео.
        /// </summary>
        private const string YOUTUBE_LINK_VIDEO = "https://www.youtube.com/watch?v=";

        /// <summary>
        ///     Контекст БД
        /// </summary>
        private readonly PanelContext _context;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="context"></param>
        public SearchByKeywordService(PanelContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<SearchByKeywordServiceDto>> GetFromYoutube(string search, int count)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = "AIzaSyDeSWC7StIOIyJtOd0hIJToi50N1ZZud78",
                ApplicationName = GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = search;
            searchListRequest.MaxResults = count;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            var searchResults = searchListResponse.Items.Select(x => new SearchByKeywordServiceDto
            {
                ChanelId = x.Id.ChannelId,
                PlaylistId = x.Id.PlaylistId,
                Title = x.Snippet.Title,
                Video = $"{YOUTUBE_LINK_VIDEO}{x.Id.VideoId}"
            });

            return searchResults;
        }

        /// <inheritdoc />
        public async Task<Result> SaveVideo(SaveLinkVideoDto saveLinkVideoDto)
        {
            await using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (saveLinkVideoDto.ProductId != null &&  saveLinkVideoDto.Videos.Count > 0)
                {
                    var videos = saveLinkVideoDto.Videos.Select(x => new Video
                        {CategoryId = x.ChanelId, Link = x.Video, PlaylistId = x.PlaylistId, Title = x.Title});
                    
                     _context.AddRange(videos);
                     _context.SaveChanges();
                    
                    var product = await _context.Products.FindAsync(saveLinkVideoDto.ProductId);

                    var videoProduct = videos.Select(video=>new VideoProduct{Product = product, ProductId = product.Id, Video = video, VideoId = video.Id});

                    _context.AddRange(videoProduct);
                    _context.SaveChanges();
                    transaction.Commit();
                    return Result.Ok();
                }

                return Result.Fail(
                    $"Запись видео не удалась. Отсутствует товар с таким идентификатором: {saveLinkVideoDto.ProductId}");
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}