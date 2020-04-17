using System.Collections.Generic;

namespace APP.OtherApi.YouTube.Dto
{
    public class SaveLinkVideoDto
    {
        /// <summary>
        ///     Список видео, которые сохраняем.
        /// </summary>
        public List<SearchByKeywordServiceDto> Videos { get; set; }

        /// <summary>
        ///     Идентификатор продукта
        /// </summary>
        public long? ProductId { get; set; }
    }
}