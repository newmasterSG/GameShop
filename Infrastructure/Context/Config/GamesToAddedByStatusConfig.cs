using Domain.Entities.GamesToAddedByStatus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Context.Config
{
    public class GamesToAddedByStatusConfig : IEntityTypeConfiguration<GamesToAddedByStatusModel>
    {
        public void Configure(EntityTypeBuilder<GamesToAddedByStatusModel> builder)
        {
            builder.ToTable("GamesToAddedByStatus");
            builder.HasKey(gtg => new { gtg.GameId, gtg.AddedByStatusId });

            builder
                .HasOne(gta => gta.Games)
                .WithOne(g => g.GamesToAddedByStatuses)
                .HasForeignKey<GamesToAddedByStatusModel>(gta => gta.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(gtg => gtg.AddedByStatus)
               .WithMany(g => g.GamesToAddedByStatus)
               .HasForeignKey(gtg => gtg.AddedByStatusId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
