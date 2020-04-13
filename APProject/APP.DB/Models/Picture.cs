using APP.Models.BaseModelsEntities;

namespace APP.DB.Models
{
    /// <summary>
    /// Сущность по работе с изображениями
    /// </summary>
    public class Picture : BaseIdNameEntity
    {
        /// <summary>
        /// Изображение.
        /// </summary>
        public byte[] Images { get; set; }
    }
}