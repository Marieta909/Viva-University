using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FirstEntity
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Customer arsen = new()
            //{
            //    Name = "Arsen Zaqarya2n",
            //    Address = "Aparan2",
            //    ContactNumber = "37493939393",
            //    Email = "arsenzaq999@gmail.com"
            //};
            //using (var dbContext = new ApplicationDbContext())
            //{
            //    try
            //    {
            //        dbContext.Customers.Add(arsen);
            //        dbContext.SaveChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Error adding customer: {ex.Message}");
            //    }
            //}
            //Console.WriteLine("Database created and seeded.");

            //NewCustomer arsen = new()
            //{
            //    Name = "Arsen Zaqarya2n",
            //    Address = "Aparan2",
            //    ContactNumber = "37493939393",
            //    Email = "arsenzaq999@gmail.com"
            //};
            //using (var dbContext = new CustomerDbContext())
            //{
            //    try
            //    {
            //        dbContext.NewCustomers.Add(arsen);
            //        dbContext.SaveChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Error adding customer: {ex.Message}");
            //    }
            //}


            //using (ApplicationDbContext context = new()) //Task 1
            //{
            //    var activeCustomers = context.Customers
            //        .Include(c => c.Orders)
            //        .Where(c => c.Orders.Any())
            //        .ToList();

            //    foreach (var customer in activeCustomers)
            //    {
            //        Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.Name}");

            //        foreach (var order in customer.Orders)
            //        {
            //            Console.WriteLine($"Order ID: {order.OrderId}, Date: {order.OrderDate}");
            //        }
            //    }
            //}

            //using (ApplicationDbContext context = new()) //Task 2
            //{
            //    var highProducts = context.Products
            //        .Where(p => p.Price > 100)
            //        .ToList();

            //    foreach (var product in highProducts)
            //    {
            //        Console.WriteLine($"product ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.Price}");

            //    }
            //}
            //using (ApplicationDbContext context = new()) //Task 3
            //{
            //    var recentOrders = context.Orders
            //        .Where(o => o.OrderDate >= DateTime.Now.AddDays(-7))
            //        .ToList();

            //    foreach (var order in recentOrders)
            //    {
            //        Console.WriteLine($"Order ID: {order.OrderId}, Date: {order.OrderDate}");
            //    }
            //}

            //using (ApplicationDbContext context = new()) //Task 4
            //{
            //    var prodSorted = context.Products
            //        .OrderBy(p => p.Price);
            //        .ToList();
            //    foreach (var prod in prodSorted)
            //        Console.WriteLine($"Price: {prod.Price}, Product ID: {prod.ProductId}, Product Name: {prod.ProductName}");
            //}

            //using (ApplicationDbContext context = new()) //Task 5
            //{
            //    var ordSorted = context.Orders
            //        .OrderByDescending(o => o.TotalAmount)
            //          .ToList();
            //    foreach (var ord in ordSorted)
            //        Console.WriteLine($"TotalAmount: {ord.TotalAmount}, Order ID: {ord.OrderId}, Date: {ord.OrderDate}");
            //}

            //using (ApplicationDbContext context = new()) //Task 6
            //{
            //    var cusSorted = context.Customers
            //        .OrderBy(c => c.Name)
            //        .ToList();
            //    foreach (var cus in cusSorted)
            //        Console.WriteLine($"Customer name: {cus.Name}, Customer ID: {cus.CustomerId}");
            //}

            //using (ApplicationDbContext context = new()) //Task 7
            //{
            //    var customerOrders = context.Orders.Join(context.Customers,
            //    o => o.CustomerId,
            //    c => c.CustomerId,
            //    (o, c) => new
            //    {
            //        Order = o,
            //        Customer = c

            //    }).ToList();

            //    foreach (var cusOrd in customerOrders)
            //        Console.WriteLine($"{cusOrd.Order.OrderId} ({cusOrd.Order.OrderDate})- {cusOrd.Customer.CustomerId} ({cusOrd.Customer.Name})");
            //}

            using (ApplicationDbContext context = new()) //task 8 
            {
                //var query = context.Orders
                //    .Join(
                //        context.OrderItems,
                //        order => order.OrderId,
                //        orderitem => orderitem.OrderId,
                //        (order, orderitem) => new
                //        {
                //            order.OrderId,
                //            order.OrderDate,
                //            orderitem.Product.ProductName,
                //            orderitem.ProductId
                //        })
                //    .Join(
                //        context.Products,
                //        joined => joined.ProductName,
                //        product => product.ProductName,
                //        (joined, product) => new
                //        {
                //            joined.OrderId,
                //            joined.OrderDate,
                //            joined.ProductName,
                //            joined.ProductId
                //        })
                //    .ToList();

                var query = context.Orders
                .Join(
                    context.OrderItems,
                    order => order.OrderId,
                    orderItem => orderItem.OrderId,
                    (order, orderItem) => new
                    {
                        order.OrderId,
                        order.OrderDate,
                        orderItem.Product.ProductName,
                        orderItem.Product.ProductId,
                    })
                .ToList();

                foreach (var result in query)
                {
                    Console.WriteLine($"Order ID: {result.OrderId}, Order Date: {result.OrderDate}");
                    Console.WriteLine($"Product: {result.ProductName}, Product ID: {result.ProductId}");
                    Console.WriteLine();
                }
            }

            //using (ApplicationDbContext context = new()) //Task 9
            //{
            //    var customerOrders = context.Customers.Join(context.Orders, 
            //    c => c.CustomerId, 
            //    o => o.CustomerId, 
            //    (c, o) => new 
            //    {
            //        Order = o,
            //        Customer = c

            //    }).ToList();

            //    foreach (var cusOrd in customerOrders)
            //        Console.WriteLine($"{cusOrd.Customer.CustomerId} ({cusOrd.Customer.Name}) - {cusOrd.Order.OrderId} ({cusOrd.Order.OrderDate})");
            //}

            //using (ApplicationDbContext context = new()) //Task 10
            //{
            //    var orderGroups = context.Orders
            //        .GroupBy(order => order.Status)
            //        .Select(group => new
            //        {
            //            Status = group.Key,
            //            OrderCount = group.Count()
            //        })
            //        .ToList();

            //    foreach (var orderGroup in orderGroups)
            //    {
            //        Console.WriteLine($"Status: {orderGroup.Status}, Order Count: {orderGroup.OrderCount}");
            //    }
            //}

            //using (ApplicationDbContext context = new()) //Task 11
            //{
            //    var product = context.Products.FirstOrDefault(p => p.ProductId == 1);
            //    if (product != null)
            //    {

            //        product.Category = "Phone";
            //        context.SaveChanges();
            //    }
            //}

            //using (ApplicationDbContext context = new()) //Task 11
            //{
            //    var prodGroups = context.Products
            //        .GroupBy(prod => prod.Category)
            //        .Select(group => new
            //        {
            //            Category = group.Key,
            //            prodAVG = group.Average(prod => prod.Price)
            //        })
            //        .ToList();

            //    foreach (var prodGroup in prodGroups)
            //    {
            //        Console.WriteLine($"Category: {prodGroup.Category}, Product Average: {prodGroup.prodAVG}");
            //    }
            //}

            //using (ApplicationDbContext context = new()) //Task 12
            //{
            //    var custGroups = context.Customers
            //        .GroupBy(cust => cust.Address)
            //        .Select(group => new
            //        {
            //            Address = group.Key,
            //            custCount = group.Count()
            //        })
            //        .ToList();

            //    foreach (var custGroup in custGroups)
            //    {
            //        Console.WriteLine($"Address: {custGroup.Address}, Customer Count: {custGroup.custCount}");
            //    }
            //}

            //using (ApplicationDbContext context = new()) //Task 13
            //{
            //    var uniqueCustomers = context.Customers
            //       .Select(c => new { c.CustomerId, c.Name })
            //       .Union(context.NewCustomers
            //           .Select(nc => new { CustomerId = nc.NewCustomerId,  nc.Name }))
            //       .ToList();

            //    foreach (var cust in uniqueCustomers)
            //    {
            //        Console.WriteLine($"{cust.CustomerId}: {cust.Name}");
            //    }
            //}

            //using (ApplicationDbContext context = new()) //Task 14
            //{
            //    context.FeaturedProducts.Add(new FeaturedProduct { ProductId = 1, Name = "Featured Product A" });
            //    context.FeaturedProducts.Add(new FeaturedProduct { ProductId = 2, Name = "Featured Product B" });
            //    context.SaveChanges();

            //    context.BestSellerProducts.Add(new BestSellerProduct { ProductId = 2, Name = "Best Seller Product B" });
            //    context.BestSellerProducts.Add(new BestSellerProduct { ProductId = 3, Name = "Best Seller Product C" });
            //    context.SaveChanges();

            //    var interProds = context.FeaturedProducts
            //        .Select(fp => fp.ProductId)
            //        .Intersect(context.BestSellerProducts
            //        .Select(bsp => bsp.ProductId))
            //        .ToList();

            //    foreach (var prodId in interProds)
            //    {
            //        Console.WriteLine($"{prodId}");
            //    }
            //}



            //using (ApplicationDbContext context = new()) //Task 15
            //{
            //    var ordersNotCancelled = context.Orders
            //        .Except(context.CancelledOrders
            //        .Select(co => co.Order))
            //        .ToList();

            //    foreach (var order in ordersNotCancelled)
            //    {
            //        Console.WriteLine($"Order ID: {order.OrderId}");
            //    }
            //}

            //using (ApplicationDbContext context = new()) //Task 16
            //{
            //    decimal totalAmount = context.Orders
            //        .Sum(order => order.TotalAmount);

            //    Console.WriteLine($"Total Amount of All Orders: {totalAmount}");
            //}

            //using (ApplicationDbContext context = new()) //Task 17
            //{
            //    decimal maxProdPrice = context.Products
            //        .Max(product => product.Price);

            //    Console.WriteLine($"Maximum Product Product: {maxProdPrice}");
            //}

            //using (ApplicationDbContext context = new()) //Task 18
            //{
            //    context.CallDetails.Add(new CallDetail
            //    {
            //        CallerNumber = "37493010718",
            //        ReceiverNumber = "374942331214",
            //        CallStartTime = DateTime.Now,
            //        CallDuration = 900 // 15 minutes
            //    });

            //    context.CallDetails.Add(new CallDetail
            //    {
            //        CallerNumber = "37493010718",
            //        ReceiverNumber = "374942331214",
            //        CallStartTime = DateTime.Now,
            //        CallDuration = 600 // 15 minutes
            //    });

            //    context.SaveChanges();

            //    decimal avgCallDuration = context.CallDetails
            //        .Average(call => call.CallDuration);

            //    Console.WriteLine($"Average Call Duration: {avgCallDuration}");
            //}

            //using (ApplicationDbContext context = new()) //Task 19
            //{
            //    var cust = context.Customers.FirstOrDefault();
            //    if (cust != null)
            //    {
            //        cust.Name = "Tom Jerry";

            //        var entry = context.Entry(cust);
            //        foreach (var property in entry.OriginalValues.Properties)
            //        {
            //            // var propertyName = property.Name;
            //            var originalValue = entry.OriginalValues[property.Name];
            //            var currentValue = entry.CurrentValues[property.Name];

            //            if (!object.Equals(originalValue, currentValue))
            //            {
            //                Console.WriteLine($"Property '{property.Name}' changed from '{originalValue}' to '{currentValue}'");
            //            }
            //        }

            //        context.SaveChanges();
            //    }

            //    var customers = context.Customers
            //        .ToList();

            //    foreach (var customer in customers)
            //    {
            //        Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.Name}");

            //    }
            //}

            //using (ApplicationDbContext context = new()) //Task 20
            //{
            //    var products = context.Products
            //        .AsNoTracking() 
            //        .ToList();  

            //    var prod = context.Products.FirstOrDefault();
            //    if (prod != null)
            //    {
            //        prod.ProductName = "Samsung A10";
            //        context.SaveChanges();
            //    }

            //    foreach (var product in products)
            //    {
            //        Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.ProductName}");
            //    }
            //}

            //using (ApplicationDbContext context = new()) //Task 21
            //{
            //    var custDelete = context.Customers.Find(3);
            //    if (custDelete != null)
            //    {
            //        custDelete.IsDeleted = true;
            //        context.SaveChanges();
            //    }

            //    var activeCustomers = context.Customers.ToList();
            //    foreach (var customer in activeCustomers)
            //    {
            //        Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.Name}");
            //    }
            //}

            //using (ApplicationDbContext context = new()) //Task 22
            //{
            //    context.Products.ExecuteUpdate(p => p.SetProperty(product => product.Price, product => product.Price * 1.1m));
            //    Console.WriteLine("Prices updated.");

            //    var updatedPrices = context.Products.ToList();
            //    foreach (var prod in updatedPrices)
            //    {
            //        Console.WriteLine($"Product ID: {prod.ProductId}, Name: {prod.Price}");
            //    }
            //}

            //    using (ApplicationDbContext context = new()) //Task 23
            //    {
            //        DateTime aYearAgo = DateTime.Now.AddYears(-1); 

            //        int deletedOrd= context.Orders
            //            .Where(order => order.OrderDate < aYearAgo)
            //            .ExecuteDelete();

            //        Console.WriteLine($"{deletedOrd} orders deleted.");
            //        var stayedOrders = context.Orders.ToList();
            //        foreach (var ord in stayedOrders)
            //        {
            //            Console.WriteLine($"Order ID: {ord.OrderId}, Date: {ord.OrderDate}");
            //        }
            //    }
            //}
        }
    }
}
