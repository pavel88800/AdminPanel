using APP.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APP.DB.Relationship
{
    internal class Product2ProductRelation : IEntityTypeConfiguration<ProductsProducts>
    {
        public void Configure(EntityTypeBuilder<ProductsProducts> builder)
        {
            builder.HasKey(x => new {x.Product1Id, x.Product2Id});

            builder
                .HasOne(x => x.Product1)
                .WithMany()
                .HasForeignKey(k => k.Product1Id);

            builder
                .HasOne(x => x.Product2)
                .WithMany()
                .HasForeignKey(k => k.Product2Id);
        }
    }
}