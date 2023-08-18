
using FirstEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static FirstEntity.Program;

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
    public DbSet<Category> Categories { get; set; }
    public DbSet<OrderViewModel> OrderViewModel { get; set; }
    public DbSet<Employee> Employee { get; set; }

    //public int CalculateAge(DateTime birthdate)
    //{
    //    int age = DateTime.Now.Year - birthdate.Year;

    //    if (birthdate > DateTime.Now.AddYears(-age))
    //    {
    //        age--;
    //    }

    //    return age;
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //էստեղ փորձի ֆունկցիադ անես, որ code-first լինի
        //modelBuilder.Entity<Product>();
        modelBuilder.Entity<CustomerAge>().HasNoKey();
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

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Customer>().Property(b => b.Timestamp).IsRowVersion();

        modelBuilder.Entity<OrderViewModel>(ovm =>
        {
            ovm.HasNoKey();
            ovm.ToView("View_OrderViewModel");
        });

        modelBuilder.Entity<Employee>().HasKey(e  => e.EmployeeId);

        modelBuilder
            .Entity<Employee>()
            .ToTable("Employees", t => t.IsTemporal());

        // modelBuilder.HasDbFunction(() => CalculateAge(default));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.;Database=FirstEntity;Trusted_Connection=True; TrustServerCertificate=True");
        optionsBuilder.UseLoggerFactory(MyLoggerFactory);
    }
    // устанавливаем фабрику логгера
    public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddProvider(new CustomLoggerProvider());    // указываем наш провайдер логгирования
    });


    //optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

}




