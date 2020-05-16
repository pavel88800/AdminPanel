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

namespace APP.BL.Services
{
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
                var picture = new Picture();
                var listPicture = new List<Picture>();

                if (productDto.Picture != null)
                    picture = await GetFile(productDto.Picture);
                
                if (productDto.Files != null && productDto.Files.Count > 0)
                    listPicture = productDto.Files.Select(file => GetFile(file).Result).ToList();

                var manufacturer = await _context.Manufacturers.FindAsync(productDto.ManufacturerId);

                var listRecomendedProducts = await _context.Products
                    .Where(x => productDto.RecomendedProductsId.Contains(x.Id))
                    .ToListAsync();

                var category = await _context.Categories.FindAsync(productDto.CategoryId);
                var product = GetNewProduct(productDto, picture, manufacturer, category);

                _context.Add(product);
                _context.SaveChanges();

                var productPictures = GetProductPictureList(listPicture, product);

                _context.AddRange(productPictures);
                _context.SaveChanges();

                var listProductProduct = GetProductProductList(listRecomendedProducts, product);

                _context.AddRange(listProductProduct);
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

        /// <inheritdoc />
        public Result UpdateProduct(ProductDto productDto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var picture = GetFile(productDto.Picture).Result;
                var listPicture = productDto.Files.Select(file => GetFile(file).Result).ToList();

                var manufacturer = _context.Manufacturers.Find(productDto.ManufacturerId);

                var listRecomendedProducts = _context.Products
                    .Where(x => productDto.RecomendedProductsId.Contains(x.Id))
                    .ToList();
                var category = _context.Categories.Find(productDto.CategoryId);

                var product = _context.Products.Find(productDto.Id);
                product.Sort = productDto.Sort;
                product.Status = productDto.Status;
                product.Name = productDto.Name;
                product.Count = productDto.Count;
                product.DataEndStock = productDto.DataEndStock;
                product.DataStartStock = productDto.DataStartStock;
                product.FullDescription = productDto.FullDescription;
                product.HtmlH1 = productDto.HtmlH1;
                product.MetaDescription = productDto.MetaDescription;
                product.MetaKeywords = productDto.MetaKeywords;
                product.MetaTitle = productDto.MetaTitle;
                product.Price = productDto.Price;
                product.SmallDescription = productDto.SmallDescription;
                product.Stock = productDto.Stock;
                product.Tags = productDto.Tags;
                product.Weight = productDto.Weight;
                product.Picture = picture;
                product.Manufacturer = manufacturer;
                product.Categories = category;

                _context.Update(product);
                _context.SaveChanges();

                var listProductProduct = GetProductProductList(listRecomendedProducts, product);

                _context.AddRange(listProductProduct);
                _context.SaveChanges();

                var productPictures = GetProductPictureList(listPicture, product);

                _context.AddRange(productPictures);
                _context.SaveChanges();

                transaction.Commit();
                return Result.Ok();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new ApplicationException(e.InnerException.Message ?? e.Message);
            }
        }

        /// <summary>
        ///     Получить объект нового проекта.
        /// </summary>
        /// <param name="productDto">Dto продукта.</param>
        /// <param name="picture">Изображение.</param>
        /// <param name="manufacturer">Производитель.</param>
        /// <param name="category">Категория.</param>
        /// <returns></returns>
        private static Product GetNewProduct(ProductDto productDto, Picture picture, Manufacturer manufacturer,
            Category category)
        {
            return new Product
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
                Picture = picture,
                Manufacturer = manufacturer,
                Categories = category
            };
        }

        /// <summary>
        ///     Получить объект типа ProductPicture
        /// </summary>
        /// <param name="listPicture">Список изображений.</param>
        /// <param name="product">Продукт.</param>
        /// <returns>Список ProductPicture</returns>
        private static List<ProductPicture> GetProductPictureList(List<Picture> listPicture, Product product)
        {
            var productPicture = new List<ProductPicture>();
            if (listPicture.Count > 0)
            {
                foreach (var pic in listPicture)
                    productPicture.Add(new ProductPicture
                    {
                        Product = product,
                        ProductId = product.Id,
                        Picture = pic
                    });

                return productPicture;
            }

            return new List<ProductPicture>();
        }

        /// <summary>
        ///     Получить объект типа ProductsProducts
        /// </summary>
        /// <param name="listRecomendedProducts">Список связанных продуктов.</param>
        /// <param name="product">Продукт.</param>
        /// <returns>Список ProductsProducts></returns>
        private static List<ProductsProducts> GetProductProductList(List<Product> listRecomendedProducts,
            Product product)
        {
            var productProducts = new List<ProductsProducts>();
            if (listRecomendedProducts.Count > 0)
            {
                foreach (var prod in listRecomendedProducts)
                    productProducts.Add(new ProductsProducts
                    {
                        Product1 = product,
                        Product1Id = product.Id,
                        Product2 = prod,
                        Product2Id = prod.Id
                    });

                return productProducts;
            }

            return new List<ProductsProducts>();
        }
    }
}