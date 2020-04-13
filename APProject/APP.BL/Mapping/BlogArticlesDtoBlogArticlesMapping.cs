using APP.BL.Dto;
using APP.DB.Models;

namespace APP.BL.Mapping
{
    /// <summary>
    ///     Маппинг для работы с BlogArticlesDto и BlogArticles.
    /// </summary>
    public class BlogArticlesDtoBlogArticlesMapping
    {
        /// <summary>
        ///     Преобразовать из BlogArticle в BlogArticlesDto
        /// </summary>
        /// <param name="blogArticle">
        ///     <see cref="BlogArticle" />
        /// </param>
        /// <returns></returns>
        public static BlogArticlesDto TransformBlogArticlesToBlogArticlesDto(BlogArticle blogArticle)
        {
            return new BlogArticlesDto
            {
                Id = blogArticle.Id,
                MetaKeywords = blogArticle.MetaKeywords,
                Description = blogArticle.Description,
                Name = blogArticle.Name,
                Status = blogArticle.Status,
                HtmlH1 = blogArticle.HtmlH1,
                BlogCategory = blogArticle.BlogCategory,
                Sort = blogArticle.Sort,
                MetaTitle = blogArticle.MetaTitle,
                MetaDescription = blogArticle.MetaDescription,
                BlogArticles = blogArticle.BlogArticles,
                RecomendedProducts = blogArticle.RecomendedProducts
            };
        }

        /// <summary>
        ///     Преобразовать из BlogArticleDto в BlogArticles
        /// </summary>
        /// <param name="blogArticle">
        ///     <see cref="BlogArticlesDto" />
        /// </param>
        /// <returns></returns>
        public static BlogArticle TransformBlogArticlesDtoToBlogArticles(BlogArticlesDto blogArticle)
        {
            return new BlogArticle
            {
                Id = blogArticle.Id,
                MetaKeywords = blogArticle.MetaKeywords,
                Description = blogArticle.Description,
                Name = blogArticle.Name,
                Status = blogArticle.Status,
                HtmlH1 = blogArticle.HtmlH1,
                BlogCategory = blogArticle.BlogCategory,
                Sort = blogArticle.Sort,
                MetaTitle = blogArticle.MetaTitle,
                MetaDescription = blogArticle.MetaDescription,
                BlogArticles = blogArticle.BlogArticles,
                RecomendedProducts = blogArticle.RecomendedProducts
            };
        }
    }
}