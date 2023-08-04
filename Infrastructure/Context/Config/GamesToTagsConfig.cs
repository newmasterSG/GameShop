using Domain.Models.GamesToTags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Context.Config
{
    public class GamesToTagsConfig : IEntityTypeConfiguration<GamesToTagsModel>
    {
        public void Configure(EntityTypeBuilder<GamesToTagsModel> builder)
        {
            builder.HasKey(gtt => new { gtt.GamesId, gtt.TagsId });

            builder
                .HasOne(gtt => gtt.Game)
                .WithMany(g => g.GamesToTags)
                .HasForeignKey(gtt => gtt.GamesId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(gtt => gtt.Tag)
                .WithMany(g => g.ToTagsModels)
                .HasForeignKey(gtt => gtt.TagsId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
