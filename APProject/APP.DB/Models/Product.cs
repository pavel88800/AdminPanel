namespace APP.DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using APP.Models.BaseModelsEntities;
    using Newtonsoft.Json;

    /// <summary>
    ///     Продукты.
    /// </summary>
    public class Product : BaseMetaInformation
    {
        /// <summary>
        ///     Промежуточное поле для хранения десериализованных данных.
        /// </summary>
        [NotMapped] private Dictionary<string, string> _deserializedCharacteristics;

        /// <summary>
        ///     Поле в БД для словаря коэффициентов
        /// </summary>
        [Column(TypeName = "jsonb")] private string _сharacteristics;

        public Product()
        {
            RecomendedProducts = new List<ProductsProducts>();
            Pictures = new List<ProductPicture>();
            VideoProduct = new List<VideoProduct>();
        }

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
        ///     Акция.
        /// </summary>
        public decimal Stock { get; set; }

        /// <summary>
        ///     Дата начала акции.
        /// </summary>
        public DateTime DataStartStock { get; set; }

        /// <summary>
        ///     Дата окончания акции.
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
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        ///     В какой категории находится товар.
        /// </summary>
        public Category Categories { get; set; }

        /// <summary>
        ///     Рекомендуемые товары.
        /// </summary>
        public List<ProductsProducts> RecomendedProducts { get; set; }

        /// <summary>
        ///     Главное изображение.
        /// </summary>
        public Picture Picture { get; set; }

        /// <summary>
        ///     Изображения
        /// </summary>
        public List<ProductPicture> Pictures { get; set; }

        /// <summary>
        ///     Ссылка на видео.
        /// </summary>
        public List<VideoProduct> VideoProduct { get; set; }

        /// <summary>
        ///     Характеристики.
        /// </summary>
        [NotMapped]
        public Dictionary<string, string> Characteristics
        {
            get { return _deserializedCharacteristics ??= DeserializeWeights(_сharacteristics); }
        }

        /// <summary>
        ///     Десериализация словаря из БД.
        /// </summary>
        /// <param name="jsonWeights"> словарь коэффициентов в jsonb. </param>
        /// <returns> Десериализованный словарь. </returns>
        private Dictionary<string, string> DeserializeWeights(string jsonWeights)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonWeights);
        }
    }
}