namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(p => p.ProductId);

                e.Property(p => p.Name)
                .IsUnicode(true)
                .HasMaxLength(50);

                e.Property(p => p.Quantity)
                .IsRequired(true);

                e.Property(p => p.Price)
                .IsRequired(true);

                e.Property(p => p.Description)
                .IsRequired(false)
                .HasMaxLength(250)
                .IsUnicode(true)
                .HasDefaultValue("No description");

            });

            modelBuilder.Entity<Customer>(e =>
            {
                e.HasKey(p => p.CustomerId);

                e.Property(p => p.Name)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(100);

                e.Property(p => p.Email)
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired(true);

                e.Property(p => p.CreditCardNumber)
                .IsUnicode(false)
                .IsRequired(true);
            });

            modelBuilder.Entity<Store>(e =>
            {
                e.HasKey(s => s.StoreId);

                e.Property(s => s.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(80);
            });

            modelBuilder.Entity<Sale>(e =>
            {
                e.HasKey(s => s.SaleId);

                e.Property(s => s.Date)
                .IsRequired(true)
                .HasColumnType("DATETIME2")
                .HasDefaultValueSql("GETDATE()");

                e.HasOne(s => s.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.ProductId);

                e.HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);

                e.HasOne(s => s.Store)
                .WithMany(st => st.Sales)
                .HasForeignKey(s => s.StoreId);
            });
        }
    }
}
