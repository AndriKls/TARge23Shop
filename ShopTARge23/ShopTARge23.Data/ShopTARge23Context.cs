using Microsoft.EntityFrameworkCore;
using ShopTARge23.Core.Domain;
//using Microsoft.EntityFrameworkCore.Relational;
//using Microsoft.Data.SqlClient;

namespace ShopTARge23.Data
{
    public class ShopTARge23Context : DbContext
    {
        public ShopTARge23Context(DbContextOptions<ShopTARge23Context> options) 
        : base(options) { }

        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToApi> FileToApis { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<FileToDatabase> FileToDatabases { get; set; }


    }
}
