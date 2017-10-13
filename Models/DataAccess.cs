using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApi_CRUD.Models {
    class EFCoreWebApi_CRUDDbContext : DbContext {
        public EFCoreWebApi_CRUDDbContext(DbContextOptions<EFCoreWebApi_CRUDDbContext> options) : base(options) { }

        public DbSet<Actor> Actor { get; set; }
        // DbSet<T> type properties for other domain models
    }

    class EFCoreWebApi_CRUDDbContextFactory {
        public static EFCoreWebApi_CRUDDbContext Create(string connectionString) {
            var optionsBuilder = new DbContextOptionsBuilder<EFCoreWebApi_CRUDDbContext>();
            optionsBuilder.UseMySQL(connectionString);
            var dbContext = new EFCoreWebApi_CRUDDbContext(optionsBuilder.Options);
            return dbContext;
        }
    }
}