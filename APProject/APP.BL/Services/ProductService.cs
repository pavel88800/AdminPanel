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
    ///     Сервис по работе с товарами.
    /// </summary>
    public class ProductService : AbstractGetService<Product>, IProductService
    {
        private readonly PanelContext _context;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="context"></param>
        public ProductService(PanelContext context) : base(context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<OffsetEntitiesDto> GetProductAsync(int offset, int count)
        {
            var result = await GetPagesAsync(offset, count);
            return result;
        }

        /// <inheritdoc />
        public async Task<Result> GetProductById(long id)
        {
            var result = await GetItemById(id);
            return Result.Ok(result);
        }

        /// <inheritdoc />
        public async Task<Result> AddProduct(ProductDto productDto)
        {
            try
            {
                var picture = await GetFile(productDto.Picture);
                var listPicture = productDto.Files.Select(file => GetFile(file).Result).ToList();

                var manufacturer = await _context.Manufacturers.FindAsync(productDto.ManufacturerId);
                var listRecomendedProducts = await _context.Products.Where(x => productDto.RecomendedProductsId.Contains(x.Id))
                    .ToListAsync();

                var category = await _context.Categories.FindAsync(productDto.CategoryId);
                
                var product = new Product
                {
                    Sort = productDto.Sort,
                    Status = productDto.Status,
                    Name = productDto.Name,
                    Count = productDto.Count,
                    DataEndStock = productDto.DataEndStock,
                    DataStartStock = productDto.DataStartStock,
                    FullDescription = productDto.FullDescription,
                    HtmlH1 = productDto.HtmlH1,
                    MetaDescription = productDto.MetaDescription,
                    MetaKeywords = productDto.MetaKeywords,
                    MetaTitle = productDto.MetaTitle,
                    Price = productDto.Price,
                    SmallDescription = productDto.SmallDescription,
                    Stock = productDto.Stock,
                    Tags = productDto.Tags,
                    Weight = productDto.Weight,
                    Pictures = listPicture,
                    Picture = picture,
                    Manufacturer = manufacturer,
                    RecomendedProducts = listRecomendedProducts,
                    Categories = category
                };
                _context.Add(product);
                _context.SaveChanges();
                return Result.Ok();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            
        }

        /// <inheritdoc />
        public Result DeleteProduct(List<long> ids)
        {
            try
            {
                DeleteItems(ids);
                return Result.Ok();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }
}