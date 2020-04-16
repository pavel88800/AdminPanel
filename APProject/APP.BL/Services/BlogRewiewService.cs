namespace APP.BL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.BL.Interfaces;
    using APP.DB;
    using APP.DB.Models;
    using APP.Models.Results;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    ///     Сервис по работе с отзывами блога.
    /// </summary>
    public class BlogRewiewService : AbstractGetService<BlogReview>, IBlogRewiewService
    {
        /// <summary>
        ///     Контекст БД
        /// </summary>
        private readonly PanelContext _context;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="context">Контекст БД.</param>
        public BlogRewiewService(PanelContext context) : base(context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Result> AddBlogRewiew(BlogRewiewDto blogRewiewDto)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var blogArticle = await _context.BlogArticles.FindAsync(blogRewiewDto.BlogArticleId);
                var blogReview = new BlogReview
                {
                    BlogArticle = blogArticle,
                    Author = blogRewiewDto.Author,
                    DateCreate = blogRewiewDto.DateCreate,
                    Rating = blogRewiewDto.Rating,
                    Status = blogRewiewDto.Status,
                    TextReview = blogRewiewDto.TextReview
                };

                await _context.AddAsync(blogReview);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Result.Ok();
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                throw new ApplicationException(e.InnerException.Message ?? e.Message);
            }
        }

        /// <inheritdoc />
        public Result DeleteBlogRewiew(List<long> ids)
        {
            try
            {
                DeleteItems(ids);
                return Result.Ok();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.InnerException.Message ?? e.Message);
            }
        }

        /// <inheritdoc />
        public async Task<OffsetEntitiesDto> GetBlogRewiewAsync(int offset, int count)
        {
            var result = await GetPagesAsync(offset, count);
            return result;
        }

        /// <inheritdoc />
        public async Task<Result> GetBlogRewiewById(long id)
        {
            var result = await GetItemById(id);
            return Result.Ok(result);
        }

        /// <inheritdoc />
        public Result UpdateBlogRewiew(BlogRewiewDto blogRewiewDto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var review = _context.BlogReviews.Include(x => x.BlogArticle)
                    .FirstOrDefault(x => x.Id == blogRewiewDto.Id);

                var blogArticle = _context.BlogArticles.Find(blogRewiewDto.BlogArticleId);
                if (review != null)
                {
                    review.BlogArticle = blogArticle;
                    review.Author = blogRewiewDto.Author;
                    review.DateCreate = blogRewiewDto.DateCreate;
                    review.Rating = blogRewiewDto.Rating;
                    review.Status = blogRewiewDto.Status;
                    review.TextReview = blogRewiewDto.TextReview;

                    _context.Update(review);
                    _context.SaveChanges();
                    transaction.Commit();

                    return Result.Ok();
                }
                return Result.Fail("Ошибка при обновлении отзыва.");
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ApplicationException(e.InnerException.Message ?? e.Message);
            }
        }
    }
}