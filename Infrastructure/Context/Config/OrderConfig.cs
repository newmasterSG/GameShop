using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Config
{
    public class OrderConfig : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder
                .ToTable("OrderEntity");

            builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);

            builder.HasMany(g => g.Games)
               .WithMany(t => t.Orders)
               .UsingEntity<OrderGameEntity>();

            builder.HasMany(g => g.GameKeys)
              .WithOne(t => t.Order);
        }
    }
}
