using Domain.Entities.OrderToGame;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Context.Config
{
    public class OrderGameConfig : IEntityTypeConfiguration<OrderGame>
    {
        public void Configure(EntityTypeBuilder<OrderGame> builder)
        {
            builder
                .ToTable("OrderToGame");

            builder
            .HasKey(og => new { og.OrderId, og.GameId });

            builder
                .HasOne(og => og.Order)
                .WithMany(o => o.OrderedGames)
                .HasForeignKey(og => og.OrderId);

            builder
                .HasOne(og => og.Game)
                .WithMany(g => g.OrderedGames)
                .HasForeignKey(og => og.GameId);
        }
    }
}
