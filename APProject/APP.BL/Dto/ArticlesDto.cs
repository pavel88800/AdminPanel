using System;
using System.Collections.Generic;
using System.Text;
using APP.Models.BaseModelsEntities;

namespace APP.BL.Dto
{
    public class ArticlesDto : BaseMetaInformation
    {
        /// <summary>
        ///     Описание.
        /// </summary>
        public string Description { get; set; }
    }
}
