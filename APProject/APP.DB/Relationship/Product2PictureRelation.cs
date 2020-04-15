using System;
using System.Collections.Generic;
using System.Text;
using APP.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APP.DB.Relationship
{
    class Product2PictureRelation :IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.PictureId });

            builder
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(k => k.ProductId);

            builder
                .HasOne(x => x.Picture)
                .WithMany()
                .HasForeignKey(k => k.PictureId);
        }
    }
}
