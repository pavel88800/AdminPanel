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

    /// <summary>
    ///     Сервис по работе с отзывами.
    /// </summary>
    public class ReviewService : AbstractGetService<Review>, IReviewService
    {
        /// <summary>
        ///     Контекст БД
        /// </summary>
        private readonly PanelContext _context;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="context">Контекст БД.</param>
        public ReviewService(PanelContext context) : base(context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<OffsetEntitiesDto> GetReviewAsync(int offset, int count)
        {
            var result = await GetPagesAsync(offset, count);
            return result;
        }

        /// <inheritdoc />
        public async Task<Result> GetReviewById(long id)
        {
            var result = await GetItemById(id);
            return Result.Ok(result);
        }

        /// <inheritdoc />
        public async Task<Result> AddReview(ReviewDto reviewDto)
        {
            try
            {
                var product = await _context.Products.FindAsync(reviewDto.ProductId);
                var review = new Review
                {
                    Product = product,
                    Author = reviewDto.Author,
                    DateCreate = reviewDto.DateCreate,
                    Status = reviewDto.Status,
                    TextReview = reviewDto.TextReview,
                    Rating = reviewDto.Rating
                };
                _context.Add(review);
                _context.SaveChanges();
                return Result.Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <inheritdoc />
        public Result DeleteReview(List<long> ids)
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
        public Result UpdateReview(ReviewDto reviewDto)
        {
            try
            {
                var review = _context.Reviews.FirstOrDefault(x => x.Id == 2);
                var product = _context.Products.Find(reviewDto.ProductId);

                if (review == null)
                    return Result.Fail("dfsf");

                review.Product = product;
                review.Author = reviewDto.Author;
                review.DateCreate = DateTime.Now;
                review.Status = reviewDto.Status;
                review.TextReview = reviewDto.TextReview;
                review.Rating = reviewDto.Rating;

                _context.Reviews.Update(review);
                _context.SaveChanges();

                return Result.Ok();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }
}