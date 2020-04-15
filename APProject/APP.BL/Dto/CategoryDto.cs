namespace APP.BL.Dto
{
    using APP.Models.BaseModelsEntities;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    ///     Дто по работе с категориями.
    /// </summary>
    public class CategoryDto : BaseMetaInformation
    {
        /// <summary>
        ///     Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Родительская категория.
        /// </summary>
        public long ParentCategoryId { get; set; }

        /// <summary>
        ///     Изображние категории.
        /// </summary>
        public IFormFile Pictures { get; set; }
    }
}