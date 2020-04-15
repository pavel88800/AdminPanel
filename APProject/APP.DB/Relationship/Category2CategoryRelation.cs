using System;
using System.Collections.Generic;
using System.Text;
using APP.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APP.DB.Relationship
{
    class Category2CategoryRelation : IEntityTypeConfiguration<CategoryCategory>
    {
        public void Configure(EntityTypeBuilder<CategoryCategory> builder)
        {
            builder.HasKey(x => new { x.Category1Id, x.Category2Id});

            builder
                .HasOne(x => x.Category1)
                .WithMany()
                .HasForeignKey(k => k.Category1Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Category2)
                .WithMany()
                .HasForeignKey(k => k.Category2Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
