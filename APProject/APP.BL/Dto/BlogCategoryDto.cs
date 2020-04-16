namespace APP.BL.Dto
{
    using APP.Models.BaseModelsEntities;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    ///     DTO  по работе с категориями блога.
    /// </summary>
    public class BlogCategoryDto : BaseMetaInformation
    {
        /// <summary>
        ///     Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Идентификатор родительской категории.
        /// </summary>
        public long BlogCategoryId { get; set; }

        /// <summary>
        ///     Изображение.
        /// </summary>
        public IFormFile Picture { get; set; }
    }
}