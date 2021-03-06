using APP.Auth.Interfaces;
using APP.Auth.Services;
using APP.Common.Helpers;
using APP.DB.Models;
using APP.Notification.Interfaces;
using APP.Notification.Services;

namespace APProject
{
    using APP.BL.Interfaces;
    using APP.BL.Services;
    using APP.DB;
    using APP.DocsModule.GoogleSheets.Interfaces;
    using APP.DocsModule.GoogleSheets.Services;
    using APP.OtherApi.YouTube.Intefaces;
    using APP.OtherApi.YouTube.Services;
    using APSwagger;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerApp();
            app.UseMvc();
            
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services
                .AddSwaggerAppGen(AuthType.Bearer)
                .AddJwtBearer(false,true)
                .AddDbContext<PanelContext>(options => options.UseSqlServer(connection))
                
                ;

            ImplementDependency(services);
        }

        private void ImplementDependency(IServiceCollection services)
        {
            services
                .AddScoped<IArticleService, ArticleService>()
                .AddScoped<IBlogArticleService, BlogArticleService>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IMetaService, MetaService>()
                .AddScoped<IReviewService, ReviewService>()
                .AddScoped<IManufacturerService, ManufacturerService>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IBlogCategoryService, BlogCategoryService>()
                .AddScoped<IBlogRewiewService, BlogRewiewService>()
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<ISearchByKeywordService, SearchByKeywordService>()
                .AddScoped<IGoogleSheetsService, GoogleSheetsService>()
                .AddScoped<IGenerateTokenService, GenerateTokenService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IRoleService, RoleService>()
                .AddScoped<IEmailNotificationService, EmailNotificationService>()
                ;
        }
    }
}