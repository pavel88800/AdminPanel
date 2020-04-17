using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APP.DB.Models
{
    /// <summary>
    ///     сущность связывающая Video и Product.
    /// </summary>
    public class VideoProduct
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        /// <summary>
        ///     Товар.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        ///     Идентификатор товара.
        /// </summary>
        public long ProductId { get; set; }

        /// <summary>
        ///     Видео.
        /// </summary>
        public Video Video { get; set; }

        /// <summary>
        ///     Идентификатор видео.
        /// </summary>
        public long VideoId { get; set; }
    }
}