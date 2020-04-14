using System;
using System.Collections.Generic;
using APP.DB.Models;
using APP.Models.BaseModelsEntities;
using Microsoft.AspNetCore.Http;

namespace APP.BL.Dto
{
    /// <summary>
    ///     Дто BlogArticles.
    /// </summary>
    public class BlogArticlesDto : BaseMetaInformation
    {
        /// <summary>
        ///     Текст статьи.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Изображение статьи.
        /// </summary>
        public IFormFile Picture { get; set; }

        /// <summary>
        ///     Категории блога.
        /// </summary>
        public long BlogCategoryId { get; set; }

        /// <summary>
        ///     Список рекомендуемых статей.
        /// </summary>
        public long[] BlogArticlesId { get; set; }

        /// <summary>
        ///     Список рекомендуемых продуктов.
        /// </summary>
        public long[] RecomendedProductsId { get; set; }
    }
}