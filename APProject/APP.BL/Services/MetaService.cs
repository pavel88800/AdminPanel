namespace APP.BL.Services
{
    using System.Linq;
    using APP.BL.Dto;
    using APP.BL.Interfaces;
    using APP.Models.Results;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    ///     Сервис по работе с мета-данными.
    /// </summary>
    public class MetaService : IMetaService
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="configuration"></param>
        public MetaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc />
        public Result GetMetaMenu()
        {
            var mainMenu = _configuration.GetSection("Menu:Catalog").GetChildren();
            var blogMenu = _configuration.GetSection("Menu:BlogCategories").GetChildren();

            var listMainMenu = mainMenu.Select(x => x.Value);
            var listBlogMenu = blogMenu.Select(x => x.Value);

            var metaResult = new MetaMainMenuDto
            {
                BlogMenu = listBlogMenu,
                CatalogMenu = listMainMenu
            };

            return Result.Ok(metaResult);
        }

        /// <inheritdoc />
        public Result GetMetaInformation()
        {
            var information = _configuration.GetSection("Information").GetChildren();
            var listInfo = information.Select(x => x.Value);
            return Result.Ok(listInfo);
        }
    }
}