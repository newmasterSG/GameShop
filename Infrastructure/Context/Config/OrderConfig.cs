using Domain.Entities.Orders;
using Domain.Entities.OrderToGame;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("Order");

            builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);

            builder.HasMany(g => g.Games)
               .WithMany(t => t.Orders)
               .UsingEntity<OrderGame>();

            builder.HasMany(g => g.GameKeys)
              .WithOne(t => t.Order);
        }
    }
}
