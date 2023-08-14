
using FirstEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class ApplicationDbContext : DbContext
{ 
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    //public DbSet<Product> FeaturedProducts { get; set; }
    //public DbSet<Product> BestSellerProducts { get; set; }
    public DbSet<FeaturedProduct> FeaturedProducts { get; set; }
    public DbSet<BestSellerProduct> BestSellerProducts { get; set; }
    public DbSet<CallDetail> CallDetails { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<NewCustomer> NewCustomers { get; set; }
    public DbSet<CancelledOrder> CancelledOrders { get; set; }
    public DbSet<OrderItems> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Product>();

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Details)
            .WithOne(d => d.Product)
            .HasForeignKey<ProductDetails>(d => d.ProductId);

        modelBuilder.Entity<Customer>()
            .HasIndex(c => c.Email)
            .IsUnique();

        //modelBuilder.Entity<Customer>()
        //    .HasAlternateKey(c => c.Email);  կարաս օգտվես 3-ի նախավերջին գլխից, առանձնացնես սրանք՝ օպտիմիզացնելու համար- կոնֆիգուրացիա

        modelBuilder.Entity<Order>()
            .HasIndex(o => o.OrderDate);

        modelBuilder.Entity<Order>()
            .HasIndex(o => new { o.CustomerId, o.Status });

        modelBuilder.Entity<Customer>()
            .HasQueryFilter(c => !c.IsDeleted);

        modelBuilder.Entity<OrderItems>().HasKey(oi => new { oi.ProductId, oi.OrderId });

        modelBuilder.Entity<OrderItems>()
        .HasOne(oi => oi.Order)
        .WithMany(o => o.OrderItems)
        .HasForeignKey(oi => oi.OrderId);


        modelBuilder.Entity<OrderItems>()
        .HasOne(oi => oi.Product)
        .WithMany(p => p.OrderItems)
        .HasForeignKey(oi => oi.ProductId);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.;Database=FirstEntity;Trusted_Connection=True; TrustServerCertificate=True");

        optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

    }

}


