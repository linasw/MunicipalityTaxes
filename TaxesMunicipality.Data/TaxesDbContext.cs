using Microsoft.EntityFrameworkCore;
using TaxesMunicipality.Core.Enums;
using TaxesMunicipality.Core.Models;

namespace TaxesMunicipality.Data
{
    public class TaxesDbContext : DbContext
    {
        public DbSet<MunicipalityTaxModel> MunicipalityTaxes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = MunicipalityTaxesDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MunicipalityTaxModel>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<MunicipalityTaxModel>()
                .Property(x => x.Municipality)
                .IsRequired();
                //.UseCollation("SQL_Latin1_General_CP1_CI_AI"); <- this should make the column case insensitive, but won't work

            modelBuilder.Entity<MunicipalityTaxModel>()
                .Property(x => x.TaxRate)
                .IsRequired();

            modelBuilder.Entity<MunicipalityTaxModel>()
                .Property(x => x.Type)
                .IsRequired();

            modelBuilder.Entity<MunicipalityTaxModel>()
                .Property(x => x.FromDate)
                .IsRequired();

            modelBuilder.Entity<MunicipalityTaxModel>()
                .Property(x => x.ToDate)
                .IsRequired();

            //initial data
            modelBuilder.Entity<MunicipalityTaxModel>().HasData(
                new MunicipalityTaxModel
                {
                    Id = 1,
                    Municipality = "Copenhagen",
                    TaxRate = 0.2,
                    Type = TaxType.Yearly,
                    FromDate = new DateTime(2024, 1, 1),
                    ToDate = new DateTime(2024, 12, 31)
                },
                new MunicipalityTaxModel
                {
                    Id = 2,
                    Municipality = "Copenhagen",
                    TaxRate = 0.4,
                    Type = TaxType.Monthly,
                    FromDate = new DateTime(2024, 5, 1),
                    ToDate = new DateTime(2024, 5, 31)
                },
                new MunicipalityTaxModel
                {
                    Id = 3,
                    Municipality = "Copenhagen",
                    TaxRate = 0.1,
                    Type = TaxType.Daily,
                    FromDate = new DateTime(2024, 1, 1),
                    ToDate = new DateTime(2024, 1, 1)
                },
                new MunicipalityTaxModel
                {
                    Id = 4,
                    Municipality = "Copenhagen",
                    TaxRate = 0.1,
                    Type = TaxType.Daily,
                    FromDate = new DateTime(2024, 12, 25),
                    ToDate = new DateTime(2024, 12, 5)
                }
            );
        }
    }
}
