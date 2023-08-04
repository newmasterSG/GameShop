using Domain.Models.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class GameConfig : IEntityTypeConfiguration<GamesModel>
    {
        public void Configure(EntityTypeBuilder<GamesModel> builder)
        {
            builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);

            builder
                .HasOne(g => g.Developer)
                .WithMany(d => d.Games)
                .HasForeignKey(g => g.DeveloperId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
