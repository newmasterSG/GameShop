using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;
using DomainLayer.Models.Games;
using DomainLayer.Models.Language;
using DomainLayer.Models.CountryCode;
using DomainLayer.Models.Tags;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainLayer.Models.GamesToLanguage;
using DomainLayer.Models.GamesToTags;

namespace DomainLayer.Context
{
    public class GameStoreDbContext : DbContext
    {

        public DbSet<GamesModel> Games { get; set; }
        public DbSet<CountryCodeModel> CountryCodes { get; set; }
        public DbSet<GamesToTagsModel> GamesToTags { get; set; }

        public DbSet<LanguageModel> Languages { get; set; }

        public DbSet<TagModel> Tags { get; set; }

        public DbSet<GamesToLanguageModel> GamesToLanguages { get; set; }
        public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Код для настройки провайдера базы данных
        }
    }
}
