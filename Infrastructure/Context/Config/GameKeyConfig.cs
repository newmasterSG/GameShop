using Domain.Entities;
using Domain.Entities.GameKeys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Config
{
    public class GameKeyConfig : IEntityTypeConfiguration<GameKey>
    {
        public void Configure(EntityTypeBuilder<GameKey> builder)
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
