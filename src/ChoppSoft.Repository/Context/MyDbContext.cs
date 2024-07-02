using ChoppSoft.Domain.Models.Addresses;
using ChoppSoft.Domain.Models.Customers;
using ChoppSoft.Domain.Models.Orders;
using ChoppSoft.Domain.Models.Orders.Items;
using ChoppSoft.Domain.Models.Products;
using ChoppSoft.Domain.Models.Resources;
using ChoppSoft.Domain.Models.Suppliers;
using ChoppSoft.Domain.Models.Users;
using ChoppSoft.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChoppSoft.Repository.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Resource> Resource { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureStringProperties(modelBuilder);
            ConfigureDateTimeProperties(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureStringProperties(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }
        }

        private void ConfigureDateTimeProperties(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?))))
            {
                property.SetColumnType("timestamp");
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var timestamp = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity is IHasTimestamps))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = timestamp;
                    entry.Property("UpdatedAt").CurrentValue = timestamp;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedAt").IsModified = false;
                    entry.Property("UpdatedAt").CurrentValue = timestamp;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
