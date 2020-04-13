using APP.BL.Dto;
using APP.DB.Models;

namespace APP.BL.Mapping
{
    /// <summary>
    ///     Маппинг для работы с ArticleDto и Article.
    /// </summary>
    public class ArticleDtoArticleMapping
    {
        /// <summary>
        ///     Преобразовать ArteclesDto в Articles
        /// </summary>
        /// <param name="dto">ArteclesDto</param>
        /// <returns></returns>
        public static Articles MapArticlesDtoToArticles(ArticlesDto dto)
        {
            return new Articles
            {
                Description = dto.Description,
                HtmlH1 = dto.HtmlH1,
                MetaDescription = dto.MetaDescription,
                MetaKeywords = dto.MetaKeywords,
                MetaTitle = dto.MetaTitle,
                Name = dto.Name,
                Sort = dto.Sort,
                Status = dto.Status
            };
        }

        /// <summary>
        ///     Преобразовать Articles в ArteclesDto
        /// </summary>
        /// <param name="art">Artecles</param>
        /// <returns></returns>
        public static ArticlesDto MapArticlesToArticlesDto(Articles art)
        {
            return new ArticlesDto
            {
                Description = art.Description,
                HtmlH1 = art.HtmlH1,
                Id = art.Id,
                MetaDescription = art.MetaDescription,
                MetaKeywords = art.MetaKeywords,
                MetaTitle = art.MetaTitle,
                Name = art.Name,
                Sort = art.Sort,
                Status = art.Status
            };
        }
    }
}