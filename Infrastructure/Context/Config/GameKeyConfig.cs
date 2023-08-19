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
    public class GameKeyConfig : IEntityTypeConfiguration<GameKeyEntity>
    {
        public void Configure(EntityTypeBuilder<GameKeyEntity> builder)
        {
            builder
                 .ToTable("GameKeys");

            builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);
        }
    }
}
