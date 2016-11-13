using CityInfo.Repository.Document;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Document
{
    public class CityInfoContext : DbContext
    {
        public DbSet<CityDocument> CityDocuments { get; set; }
        public DbSet<PointOfInterestDocument> PointOfInterestDocuments { get; set; }

        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {
            //Database.EnsureCreated(); creates db if it does note exist.
            //Database.Migrate(); triggers migration which is already added (by EFCore.Tools) via 
                               // PM > Add-Migration TheNameOfMigration (Kinda PM> Update-Database)
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CityDocument>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CityDocument>()
                .Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<CityDocument>()
                .Property(c => c.Description)
                .HasMaxLength(200);

            modelBuilder.Entity<PointOfInterestDocument>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
