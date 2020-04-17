namespace APP.DB.Relationship
{
    using APP.DB.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class VideoProductRelation : IEntityTypeConfiguration<VideoProduct>
    {
        public void Configure(EntityTypeBuilder<VideoProduct> builder)
        {
            builder.HasKey(x => new {x.ProductId, x.VideoId});

            builder
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(k => k.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Video)
                .WithMany()
                .HasForeignKey(k => k.VideoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}