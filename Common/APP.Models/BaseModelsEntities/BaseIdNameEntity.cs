namespace APP.Models.BaseModelsEntities
{
    public class BaseIdNameEntity : BaseIdEntity
    {
        /// <summary>
        ///     Наименование.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        ///     Статус.
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        ///     Сортировка.
        /// </summary>
        public int Sort { get; set; }
    }
}