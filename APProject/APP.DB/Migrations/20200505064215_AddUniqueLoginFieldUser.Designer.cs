﻿// <auto-generated />
using System;
using APP.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APP.DB.Migrations
{
    [DbContext(typeof(PanelContext))]
    [Migration("20200505064215_AddUniqueLoginFieldUser")]
    partial class AddUniqueLoginFieldUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APP.DB.Models.Articles", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HtmlH1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaKeywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Articleses");
                });

            modelBuilder.Entity("APP.DB.Models.BlogArticle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BlogArticleId")
                        .HasColumnType("bigint");

                    b.Property<long?>("BlogCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HtmlH1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaKeywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PictureId")
                        .HasColumnType("bigint");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BlogArticleId");

                    b.HasIndex("BlogCategoryId");

                    b.HasIndex("PictureId");

                    b.ToTable("BlogArticles");
                });

            modelBuilder.Entity("APP.DB.Models.BlogCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HtmlH1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaKeywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PictureId")
                        .HasColumnType("bigint");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PictureId");

                    b.ToTable("BlogCategory");
                });

            modelBuilder.Entity("APP.DB.Models.BlogCategory2BlogCategory", b =>
                {
                    b.Property<long>("BlogCategory1Id")
                        .HasColumnType("bigint");

                    b.Property<long>("BlogCategory2Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("BlogCategoryId")
                        .HasColumnType("bigint");

                    b.HasKey("BlogCategory1Id", "BlogCategory2Id");

                    b.HasIndex("BlogCategory2Id");

                    b.HasIndex("BlogCategoryId");

                    b.ToTable("BlogCategory2BlogCategories");
                });

            modelBuilder.Entity("APP.DB.Models.BlogReview", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("BlogArticleId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TextReview")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogArticleId");

                    b.ToTable("BlogReviews");
                });

            modelBuilder.Entity("APP.DB.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HtmlH1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaKeywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("APP.DB.Models.CategoryCategory", b =>
                {
                    b.Property<long>("Category1Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Category2Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.HasKey("Category1Id", "Category2Id");

                    b.HasIndex("Category2Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryCategory");
                });

            modelBuilder.Entity("APP.DB.Models.CategoryPicture", b =>
                {
                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("PictureId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CategoryId1")
                        .HasColumnType("bigint");

                    b.HasKey("CategoryId", "PictureId");

                    b.HasIndex("CategoryId1");

                    b.HasIndex("PictureId");

                    b.ToTable("CategoryPicture");
                });

            modelBuilder.Entity("APP.DB.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Faxs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("APP.DB.Models.Manufacturer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("APP.DB.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TimeAdd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeUpdate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("APP.DB.Models.OrderProduct", b =>
                {
                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long?>("OrderId1")
                        .HasColumnType("bigint");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("OrderId1");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("APP.DB.Models.Picture", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Images")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("APP.DB.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BlogArticleId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CategoriesId")
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEndStock")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataStartStock")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HtmlH1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ManufacturerId")
                        .HasColumnType("bigint");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaKeywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PictureId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SmallDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<decimal>("Stock")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BlogArticleId");

                    b.HasIndex("CategoriesId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PictureId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("APP.DB.Models.ProductPicture", b =>
                {
                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long>("PictureId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProductId1")
                        .HasColumnType("bigint");

                    b.HasKey("ProductId", "PictureId");

                    b.HasIndex("PictureId");

                    b.HasIndex("ProductId1");

                    b.ToTable("ProductPicture");
                });

            modelBuilder.Entity("APP.DB.Models.ProductsProducts", b =>
                {
                    b.Property<long>("Product1Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Product2Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Product1Id", "Product2Id");

                    b.HasIndex("Product2Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductsProducts");
                });

            modelBuilder.Entity("APP.DB.Models.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TextReview")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("APP.DB.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("APP.DB.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique()
                        .HasFilter("[Login] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("APP.DB.Models.Video", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaylistId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("APP.DB.Models.VideoProduct", b =>
                {
                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long>("VideoId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProductId1")
                        .HasColumnType("bigint");

                    b.Property<long?>("VideoId1")
                        .HasColumnType("bigint");

                    b.HasKey("ProductId", "VideoId");

                    b.HasIndex("ProductId1");

                    b.HasIndex("VideoId");

                    b.HasIndex("VideoId1");

                    b.ToTable("VideoProduct");
                });

            modelBuilder.Entity("APP.DB.Models.BlogArticle", b =>
                {
                    b.HasOne("APP.DB.Models.BlogArticle", null)
                        .WithMany("BlogArticles")
                        .HasForeignKey("BlogArticleId");

                    b.HasOne("APP.DB.Models.BlogCategory", "BlogCategory")
                        .WithMany()
                        .HasForeignKey("BlogCategoryId");

                    b.HasOne("APP.DB.Models.Picture", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureId");
                });

            modelBuilder.Entity("APP.DB.Models.BlogCategory", b =>
                {
                    b.HasOne("APP.DB.Models.Picture", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureId");
                });

            modelBuilder.Entity("APP.DB.Models.BlogCategory2BlogCategory", b =>
                {
                    b.HasOne("APP.DB.Models.BlogCategory", "BlogCategory1")
                        .WithMany()
                        .HasForeignKey("BlogCategory1Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("APP.DB.Models.BlogCategory", "BlogCategory2")
                        .WithMany()
                        .HasForeignKey("BlogCategory2Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("APP.DB.Models.BlogCategory", null)
                        .WithMany("BlogCategories")
                        .HasForeignKey("BlogCategoryId");
                });

            modelBuilder.Entity("APP.DB.Models.BlogReview", b =>
                {
                    b.HasOne("APP.DB.Models.BlogArticle", "BlogArticle")
                        .WithMany()
                        .HasForeignKey("BlogArticleId");
                });

            modelBuilder.Entity("APP.DB.Models.CategoryCategory", b =>
                {
                    b.HasOne("APP.DB.Models.Category", "Category1")
                        .WithMany()
                        .HasForeignKey("Category1Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("APP.DB.Models.Category", "Category2")
                        .WithMany()
                        .HasForeignKey("Category2Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("APP.DB.Models.Category", null)
                        .WithMany("ParentCategory")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("APP.DB.Models.CategoryPicture", b =>
                {
                    b.HasOne("APP.DB.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APP.DB.Models.Category", null)
                        .WithMany("Pictures")
                        .HasForeignKey("CategoryId1");

                    b.HasOne("APP.DB.Models.Picture", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APP.DB.Models.Order", b =>
                {
                    b.HasOne("APP.DB.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("APP.DB.Models.OrderProduct", b =>
                {
                    b.HasOne("APP.DB.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("APP.DB.Models.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId1");

                    b.HasOne("APP.DB.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("APP.DB.Models.Product", b =>
                {
                    b.HasOne("APP.DB.Models.BlogArticle", null)
                        .WithMany("RecomendedProducts")
                        .HasForeignKey("BlogArticleId");

                    b.HasOne("APP.DB.Models.Category", "Categories")
                        .WithMany()
                        .HasForeignKey("CategoriesId");

                    b.HasOne("APP.DB.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("APP.DB.Models.Picture", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureId");
                });

            modelBuilder.Entity("APP.DB.Models.ProductPicture", b =>
                {
                    b.HasOne("APP.DB.Models.Picture", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APP.DB.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APP.DB.Models.Product", null)
                        .WithMany("Pictures")
                        .HasForeignKey("ProductId1");
                });

            modelBuilder.Entity("APP.DB.Models.ProductsProducts", b =>
                {
                    b.HasOne("APP.DB.Models.Product", "Product1")
                        .WithMany()
                        .HasForeignKey("Product1Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("APP.DB.Models.Product", "Product2")
                        .WithMany()
                        .HasForeignKey("Product2Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("APP.DB.Models.Product", null)
                        .WithMany("RecomendedProducts")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("APP.DB.Models.Review", b =>
                {
                    b.HasOne("APP.DB.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("APP.DB.Models.User", b =>
                {
                    b.HasOne("APP.DB.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("APP.DB.Models.VideoProduct", b =>
                {
                    b.HasOne("APP.DB.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("APP.DB.Models.Product", null)
                        .WithMany("VideoProduct")
                        .HasForeignKey("ProductId1");

                    b.HasOne("APP.DB.Models.Video", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("APP.DB.Models.Video", null)
                        .WithMany("VideoProduct")
                        .HasForeignKey("VideoId1");
                });
#pragma warning restore 612, 618
        }
    }
}
