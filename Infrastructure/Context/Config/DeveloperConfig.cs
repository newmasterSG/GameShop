using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Context.Config
{
    public class DeveloperConfig : IEntityTypeConfiguration<DevelopersEntity>
    {
        public void Configure(EntityTypeBuilder<DevelopersEntity> builder)
        {
            builder.ToTable("Developer");

            builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);
        }
    }
}
