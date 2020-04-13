using System.Collections.Generic;
using APP.Models.BaseModelsEntities;

namespace APP.DB.Models
{
    /// <summary>
    ///     Статьи блога.
    /// </summary>
    public class BlogArticle : BaseMetaInformation
    {
        public BlogArticle()
        {
            RecomendedProducts = new List<Product>();
            BlogArticles = new List<BlogArticle>();
        }

        /// <summary>
        ///     Текст статьи.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Изображение статьи.
        /// </summary>
        public Picture Picture { get; set; }

        /// <summary>
        ///     Категории блога.
        /// </summary>
        public BlogCategory BlogCategory { get; set; }

        /// <summary>
        ///     Список рекомендуемых статей.
        /// </summary>
        public List<BlogArticle> BlogArticles { get; set; }

        /// <summary>
        ///     Список рекомендуемых продуктов.
        /// </summary>
        public List<Product> RecomendedProducts { get; set; }
    }
}