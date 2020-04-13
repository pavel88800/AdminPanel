using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.OpenApi.Models;

namespace APSwagger
{
    public class SwaggerInfo
    {
        /// <summary>
        ///     Конструктор со значениями по умолчанию.
        /// </summary>
        public SwaggerInfo()
        {
            ApiName = "My API v1";
            VersionName = "v1";
            ApiUrl = "/swagger/v1/swagger.json";
            Api.Title = "My API";
            Api.Description = "Default created API";
            Api.Version = "v1";
        }

        /// <summary>
        ///     Наименование версии API.
        /// </summary>
        private string _versionName;
        /// <summary>
        ///     Информация о заголовке, версии и описании.
        /// </summary>
        public OpenApiInfo Api { get; set; } = new OpenApiInfo();

        /// <summary>
        ///     Наименование API.
        /// </summary>
        public string ApiName { get; set; }

        /// <summary>
        ///     Путь к документации API.    
        /// </summary>
        public string ApiUrl { get; private set; }

        /// <summary>
        ///     Свойство наименования версии API.
        /// </summary>
        public string VersionName
        {
            get => _versionName;
            set
            {
                _versionName = value;
                ApiUrl = $"/swagger/{value}/swagger.json";
            }
        }
    }
}
