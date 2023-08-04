using Domain.Models.Developer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Context.Config
{
    public class DeveloperConfig : IEntityTypeConfiguration<DevelopersModel>
    {
        public void Configure(EntityTypeBuilder<DevelopersModel> builder)
        {
            builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);
        }
    }
}
