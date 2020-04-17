namespace APP.OtherApi.YouTube.Dto
{
    public class SearchByKeywordServiceDto
    {
        /// <summary>
        ///     Название
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Ссылка на видео
        /// </summary>
        public string Video { get; set; }

        /// <summary>
        ///     Идентификатор канала
        /// </summary>
        public string? ChanelId { get; set; }

        /// <summary>
        ///     Идентификатор плейлиста
        /// </summary>
        public string? PlaylistId { get; set; }
    }
}