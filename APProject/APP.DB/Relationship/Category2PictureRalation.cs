using APP.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APP.DB.Relationship
{
    /// <summary>
    ///     Класс реализующий связь M2M для Category Picture
    /// </summary>
    internal class Category2PictureRalation : IEntityTypeConfiguration<CategoryPicture>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<CategoryPicture> builder)
        {
            builder.HasKey(x => new { x.CategoryId, x.PictureId });

            builder
                .HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(k => k.CategoryId);

            builder
                .HasOne(x => x.Picture)
                .WithMany()
                .HasForeignKey(k => k.PictureId);
        }
    }
}