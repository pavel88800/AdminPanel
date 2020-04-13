using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using APP.Models.BaseModelsEntities;
using Newtonsoft.Json;

namespace APP.DB.Models
{
    /// <summary>
    ///     Продукты.
    /// </summary>
    public class Product : BaseMetaInformation
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
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        ///     В какой категории находится товар.
        /// </summary>
        public Category Categories { get; set; }

        /// <summary>
        ///     Рекомендуемые товары.
        /// </summary>
        public List<Product> RecomendedProducts { get; set; }

        /// <summary>
        ///     Главное изображение.
        /// </summary>
        public Picture Picture { get; set; }

        /// <summary>
        ///     Изображения
        /// </summary>
        public List<Picture> Pictures { get; set; }
        

        /// <summary>
        ///     Словарь коэффициентов ребер для классов дорог.
        /// </summary>
        [NotMapped]
        public Dictionary<string, string> Characteristics
        {
            get
            {
                return _deserializedCharacteristics ??= DeserializeWeights(_сharacteristics);
            }
        }

        /// <summary>
        ///     Промежуточное поле для хранения десериализованных данных.
        /// </summary>
        [NotMapped]
        private Dictionary<string, string> _deserializedCharacteristics;

        /// <summary>
        ///     Поле в БД для словаря коэффициентов
        /// </summary>
        [Column(TypeName = "jsonb")]
        private string _сharacteristics;

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