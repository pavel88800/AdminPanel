using System;
using System.Collections.Generic;
using APP.DB.Models;
using APP.Models.BaseModelsEntities;
using Microsoft.AspNetCore.Http;

namespace APP.BL.Dto
{
    public class ProductDto : BaseMetaInformation
    {
        /// <summary>
        ///     Описание.
        /// </summary>
        public string FullDescription { get; set; }

        /// <summary>
        ///     Краткое описание.
        /// </summary>
        public string SmallDescription { get; set; }

        /// <summary>
        ///     Теги товара.
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        ///     Цена товара.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Акция.
        /// </summary>
        public decimal Stock { get; set; }

        /// <summary>
        /// Дата начала акции.
        /// </summary>
        public DateTime DataStartStock { get; set; }

        /// <summary>
        /// Дата окончания акции.
        /// </summary>
        public DateTime DataEndStock { get; set; }

        /// <summary>
        ///     Количество.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        ///     Вес товара.
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        ///     Производитель.
        /// </summary>
        public long ManufacturerId { get; set; }

        /// <summary>
        ///     В какой категории находится товар.
        /// </summary>
        public long CategoryId { get; set; }

        /// <summary>
        ///     Рекомендуемые товары.
        /// </summary>
        public long[] RecomendedProductsId { get; set; }

        /// <summary>
        ///     Главное изображение.
        /// </summary>
        public IFormFile Picture { get; set; }

        /// <summary>
        ///     Изображения
        /// </summary>
        public IFormFileCollection Files { get; set; }
    }
}