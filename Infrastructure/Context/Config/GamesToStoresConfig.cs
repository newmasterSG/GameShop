using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Context.Config
{
    public class GamesToStoresConfig : IEntityTypeConfiguration<GamesToStoresEntity>
    {
        public void Configure(EntityTypeBuilder<GamesToStoresEntity> builder)
        {
            builder.ToTable("GamesToStores");

            builder.HasKey(gtg => new { gtg.GameId, gtg.StoreId });

            builder
                .HasOne(gta => gta.Game)
                .WithMany(g => g.GamesToStores)
                .HasForeignKey(gta => gta.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasOne(gtg => gtg.Store)
               .WithMany(g => g.GamesToStores)
               .HasForeignKey(gtg => gtg.StoreId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
