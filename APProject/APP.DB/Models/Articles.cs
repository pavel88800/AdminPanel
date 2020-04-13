using APP.Models.BaseModelsEntities;

namespace APP.DB.Models
{
    /// <summary>
    ///     Статьи.
    /// </summary>
    public class Articles : BaseMetaInformation
    {
        /// <summary>
        ///     Описание.
        /// </summary>
        public string Description { get; set; }
        
    }
}