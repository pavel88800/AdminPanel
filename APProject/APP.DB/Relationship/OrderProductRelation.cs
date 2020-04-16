namespace APP.DB.Relationship
{
    using APP.DB.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class OrderProductRelation : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(x => new {x.OrderId, x.ProductId});

            builder
                .HasOne(x => x.Order)
                .WithMany()
                .HasForeignKey(k => k.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(k => k.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}