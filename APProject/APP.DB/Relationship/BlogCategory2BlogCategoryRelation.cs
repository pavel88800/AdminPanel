namespace APP.DB.Relationship
{
    using APP.DB.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Связь для BlogCategory2BlogCategory
    /// </summary>
    internal class BlogCategory2BlogCategoryRelation : IEntityTypeConfiguration<BlogCategory2BlogCategory>
    {
        public void Configure(EntityTypeBuilder<BlogCategory2BlogCategory> builder)
        {
            builder.HasKey(x => new {x.BlogCategory1Id, x.BlogCategory2Id});

            builder
                .HasOne(x => x.BlogCategory1)
                .WithMany()
                .HasForeignKey(k => k.BlogCategory1Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.BlogCategory2)
                .WithMany()
                .HasForeignKey(k => k.BlogCategory2Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}