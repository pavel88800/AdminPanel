namespace APP.DB
{
    using APP.DB.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    ///     Контекст Админ-панели.
    /// </summary>
    public class PanelContext : DbContext
    {
        public PanelContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        ///     Статьи.
        /// </summary>
        public DbSet<Articles> Articleses { get; set; }

        /// <summary>
        ///     Статьи блога.
        /// </summary>
        public DbSet<BlogArticle> BlogArticles { get; set; }

        /// <summary>
        ///     Категории Блога.
        /// </summary>
        public DbSet<BlogCategory> BlogCategory { get; set; }

        /// <summary>
        ///     Отзывы отзыва.
        /// </summary>
        public DbSet<BlogReview> BlogReviews { get; set; }

        /// <summary>
        ///     Категории.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        ///     Производители.
        /// </summary>
        public DbSet<Manufacturer> Manufacturers { get; set; }

        /// <summary>
        ///     Изображения.
        /// </summary>
        public DbSet<Picture> Pictures { get; set; }

        /// <summary>
        ///     Товары.
        /// </summary>
        /// создла
        public DbSet<Product> Products { get; set; }

        /// <summary>
        ///     Отзывы.
        /// </summary>
        public DbSet<Review> Reviews { get; set; }

        /// <summary>
        ///     Покупатели.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        ///     Заказы.
        /// </summary>
        public DbSet<Order> Orders { get; set; }


        public DbSet<CategoryPicture> CategoryPicture { get; set; }

        public DbSet<CategoryCategory> CategoryCategory { get; set; }


        /// <summary>
        ///     Инициализация контекста.
        /// </summary>
        public void Init()
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}