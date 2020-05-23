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

        /// <summary>
        ///     Связь категории и изображений.
        /// </summary>
        public DbSet<CategoryPicture> CategoryPicture { get; set; }

        /// <summary>
        ///     Связь категории и категории.
        /// </summary>
        public DbSet<CategoryCategory> CategoryCategory { get; set; }

        /// <summary>
        ///     Связь категории блога и категории блога.
        /// </summary>
        public DbSet<BlogCategory2BlogCategory> BlogCategory2BlogCategories { get; set; }

        /// <summary>
        ///     Пользователи.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        ///     Роли.
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        ///     Доски.
        /// </summary>
        public DbSet<Boards> Boards { get; set; }

        /// <summary>
        ///     Карточки.
        /// </summary>
        public DbSet<Card> Cards { get; set; }

        /// <summary>
        ///     Колонки.
        /// </summary>
        public DbSet<Column> Columns { get; set; }

        /// <summary>
        ///     Задачи.
        /// </summary>
        public DbSet<Task> Tasks { get; set; }

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