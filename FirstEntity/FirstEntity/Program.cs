using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            //    var highOrders = context.Orders
            //        .Where(p => p.Price > 100)
            //        .ToList();

            //    foreach (var Order in highOrders)
            //    {
            //        Console.WriteLine($"Order ID: {Order.OrderId}, Name: {Order.OrderName}, Price: {Order.Price}");

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
            //    var prodSorted = context.Orders
            //        .OrderBy(p => p.Price);
            //        .ToList();
            //    foreach (var prod in prodSorted)
            //        Console.WriteLine($"Price: {prod.Price}, Order ID: {prod.OrderId}, Order Name: {prod.OrderName}");
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

            //using (ApplicationDbContext context = new()) //task 8 
            //{
            //var query = context.Orders
            //    .Join(
            //        context.OrderItems,
            //        order => order.OrderId,
            //        orderitem => orderitem.OrderId,
            //        (order, orderitem) => new
            //        {
            //            order.OrderId,
            //            order.OrderDate,
            //            orderitem.Order.OrderName,
            //            orderitem.OrderId
            //        })
            //    .Join(
            //        context.Orders,
            //        joined => joined.OrderName,
            //        Order => Order.OrderName,
            //        (joined, Order) => new
            //        {
            //            joined.OrderId,
            //            joined.OrderDate,
            //            joined.OrderName,
            //            joined.OrderId
            //        })
            //    .ToList();

            //var query = context.Orders
            //    .Join(
            //        context.OrderItems,
            //        order => order.OrderId,
            //        orderItem => orderItem.OrderId,
            //        (order, orderItem) => new
            //        {
            //            order.OrderId,
            //            order.OrderDate,
            //            orderItem.Order.OrderName,
            //            orderItem.Order.OrderId,
            //        })
            //    .ToList();

            //    foreach (var result in query)
            //    {
            //        Console.WriteLine($"Order ID: {result.OrderId}, Order Date: {result.OrderDate}");
            //        Console.WriteLine($"Order: {result.OrderName}, Order ID: {result.OrderId}");
            //        Console.WriteLine();
            //    }
            //}

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
            //    var Order = context.Orders.FirstOrDefault(p => p.OrderId == 1);
            //    if (Order != null)
            //    {

            //        Order.Category = "Phone";
            //        context.SaveChanges();
            //    }
            //}

            //using (ApplicationDbContext context = new()) //Task 11 ????????????????????????????????????????????????????
            //{
            //    var prodGroups = context.Orders
            //        .GroupBy(prod => prod.Category)
            //        .Select(group => new
            //        {
            //            Category = group.Key,
            //            prodAVG = group.Average(prod => prod.Price)
            //        })
            //        .ToList();

            //    foreach (var prodGroup in prodGroups)
            //    {
            //        Console.WriteLine($"Category: {prodGroup.Category}, Order Average: {prodGroup.prodAVG}");
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
            //    context.FeaturedOrders.Add(new FeaturedOrder { OrderId = 1, Name = "Featured Order A" });
            //    context.FeaturedOrders.Add(new FeaturedOrder { OrderId = 2, Name = "Featured Order B" });
            //    context.SaveChanges();

            //    context.BestSellerOrders.Add(new BestSellerOrder { OrderId = 2, Name = "Best Seller Order B" });
            //    context.BestSellerOrders.Add(new BestSellerOrder { OrderId = 3, Name = "Best Seller Order C" });
            //    context.SaveChanges();

            //    var interProds = context.FeaturedOrders
            //        .Select(fp => fp.OrderId)
            //        .Intersect(context.BestSellerOrders
            //        .Select(bsp => bsp.OrderId))
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
            //    decimal maxProdPrice = context.Orders
            //        .Max(Order => Order.Price);

            //    Console.WriteLine($"Maximum Order Order: {maxProdPrice}");
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
            //    var Orders = context.Orders
            //        .AsNoTracking() 
            //        .ToList();  

            //    var prod = context.Orders.FirstOrDefault();
            //    if (prod != null)
            //    {
            //        prod.OrderName = "Samsung A10";
            //        context.SaveChanges();
            //    }

            //    foreach (var Order in Orders)
            //    {
            //        Console.WriteLine($"Order ID: {Order.OrderId}, Name: {Order.OrderName}");
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
            //    context.Orders.ExecuteUpdate(p => p.SetProperty(Order => Order.Price, Order => Order.Price * 1.1m));
            //    Console.WriteLine("Prices updated.");

            //    var updatedPrices = context.Orders.ToList();
            //    foreach (var prod in updatedPrices)
            //    {
            //        Console.WriteLine($"Order ID: {prod.OrderId}, Name: {prod.Price}");
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

            //-------------------------------------------Գլուխ 7-8-----------------------------------------

            //using (ApplicationDbContext context = new()) //Task 1
            //{
            //    var specPrice = 400;
            //    var priceGreater = context.Orders.FromSqlRaw("Select * from Orders where Price > {0}", specPrice).ToList();

            //    foreach (var prod in priceGreater)
            //        Console.WriteLine($"{prod.OrderName} -  {prod.Price}");
            //}

            //using (ApplicationDbContext context = new()) //Task 2
            //{
            //    var fixedPrice = 200000;
            //    var categUpdate = "Phone";
            //    var priceGreater = context.Database.ExecuteSqlRaw($"Update Orders set Price = {fixedPrice} " +
            //        $"where CategoryId IN (select CategoryId from Categories where CategoryName = '{categUpdate}')");
            //    Console.WriteLine("Price has Updated.");
            //}

            //using (ApplicationDbContext context = new()) //Task 3
            //{
            //    var targetSubstring = "%374%";
            //    var specNumber = context.Customers.FromSqlInterpolated($"select * from Customers where ContactNumber LIKE {targetSubstring}").ToList();
            //    foreach (var num in specNumber)
            //        Console.WriteLine($"{num.Name} - {num.ContactNumber}");

            //}

            //using (ApplicationDbContext context = new()) //Task 4
            //{
            //    var sixMonthsAgo = DateTime.Now.AddMonths(-6);

            //    context.Database.ExecuteSqlInterpolated($@"delete from Customers where CustomerId Not IN 
            //                 (select distinct Orders.CustomerId from Orders where Orders.OrderDate >= {sixMonthsAgo})");
            //    foreach (var cust in context.Customers.ToList())
            //        Console.WriteLine($"{cust.CustomerId} - {cust.Name}");


            //--------------------------------------------------------------JOin


            //var sixMonthsAgo = DateTime.Now.AddMonths(-6);

            //context.Database.ExecuteSqlInterpolated($@"delete from Customers where CustomerId NOT IN 
            //            (select distinct Customers.CustomerId
            //            from Customers
            //            join Orders on Customers.CustomerId = Orders.CustomerId
            //            where Orders.OrderDate >= {sixMonthsAgo})");

            //foreach (var cust in context.Customers.ToList())
            //{
            //    Console.WriteLine($"{cust.CustomerId} - {cust.Name}");
            //}

            //using (ApplicationDbContext context = new()) //Task 5
            //{
            //    int customerId = 2;
            //    var customer = context.Customers.Where(c => c.CustomerId == customerId)
            //        .Select(c => c.Birthdate)
            //        .FirstOrDefault();

            //    SqlParameter sqlParameter = new("@age", customer);
            //    var age = context.Set<CustomerAge>().FromSqlRaw("Select dbo.CalculateAge(@age) as Age", sqlParameter).FirstOrDefault();
            //    Console.WriteLine(age.Age);
            //}

            //using (ApplicationDbContext context = new()) //Task 5 code-first Db context approach
            //{
            //    int customerId = 1;
            //    var customer = context.Customers.FirstOrDefault(c => c.CustomerId == customerId);

            //    if (customer != null)
            //    {
            //        int age = context.CalculateAge(customer.Birthdate);
            //        Console.WriteLine($"Customer ID {customerId} is {age} years old.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Customer not found.");
            //    }
            //}



            //using (ApplicationDbContext context = new()) //Task 5 Code-First migration approach
            //{
            //    int customerId = 1;
            //    var customer = context.Customers.Where(c => c.CustomerId == customerId)
            //        .Select(c => c.Birthdate)
            //        .FirstOrDefault();

            //    SqlParameter sqlParameter = new("@age", customer);
            //    var age = context.Set<CustomerAge>().FromSqlRaw("Select dbo.CalculateAge1(@age) as Age", sqlParameter).FirstOrDefault();
            //    Console.WriteLine(age.Age);
            //}

            //using (ApplicationDbContext context = new()) //Task 6
            //{
            //    SqlParameter param = new SqlParameter("@threshold", 1000);
            //    var users = context.Orders.FromSqlRaw("SELECT * FROM dbo.GetOrdersAboveThreshold (@threshold)", param).ToList();
            //    foreach (var u in users)
            //        Console.WriteLine($"{u.OrderId} - {u.TotalAmount}");
            //}

            //using (ApplicationDbContext context = new()) //Task 7
            //{
            //    SqlParameter param = new()
            //    {
            //        ParameterName = "@countOrders",
            //        SqlDbType = SqlDbType.Int,
            //        Direction = ParameterDirection.Output
            //    };
            //    context.Database.ExecuteSqlRaw("GetTotalCountOrders {0}, @countOrders OUT",2, param);
            //    Console.WriteLine(param.Value);
            //}

            //using (ApplicationDbContext context = new()) //Task 8
            //{
            //    SqlParameter param = new("@id", 1);
            //    var calls = context.CallDetails.FromSqlRaw("CalculateAndUpdateAverageCallDuration @id", param).ToList();

            //}

            //using (ApplicationDbContext context = new()) //Task 9
            //{
            //    try
            //    {
            //        Customer? customer = context.Customers.FirstOrDefault();
            //        if (customer != null)
            //        {
            //            customer.Name = "Bob";
            //            context.SaveChanges();
            //            Console.WriteLine(customer.Name);
            //        }

            //        throw new DbUpdateConcurrencyException();
            //    }
            //    catch (DbUpdateConcurrencyException ex)
            //    {
            //        string logFilePath = "C:\\Users\\marie\\Desktop\\ErrorLog.log";

            //        using (StreamWriter writer = new StreamWriter(logFilePath, true))
            //        {
            //            writer.WriteLine($"[Error DateTime]: {DateTime.Now}");
            //            writer.WriteLine($"[Error Message]: {ex.Message}");
            //            writer.WriteLine($"[Stack Trace]: {ex.StackTrace}");
            //            writer.WriteLine(new string('-', 50));
            //        }
            //    }
            //}

            //using (ApplicationDbContext context = new()) //Task 10
            //{

            //    Customer user1 = new() { Name = "Tom", Address="Yerevan", ContactNumber = "37493935555", Email="asdfgh@gmail.com" };
            //    Customer user2 = new() { Name = "Alice", Address = "Yerevan", ContactNumber = "37493935556", Email = "asdfghghb@gmail.com" };

            //    context.Customers.Add(user1);
            //    context.Customers.Add(user2);
            //    context.SaveChanges();

            //    var users = context.Customers.ToList();
            //    Console.WriteLine("Список пользователей:");
            //    foreach (Customer u in users)
            //    {
            //        Console.WriteLine($"{u.CustomerId}.{u.Name}");
            //    }
            //}

            //Func<ApplicationDbContext, int, Customer?> customerById =
            //EF.CompileQuery((ApplicationDbContext context, int id) => context.Customers.Where(c => c.CustomerId == id).FirstOrDefault());
            //using (ApplicationDbContext context = new()) //--------------------------------------------------------Task 11
            //{
            //    var customer = customerById(context, 2);
            //    if (customer != null) Console.WriteLine($"{customer.Name} ");
            //}


            //using (ApplicationDbContext db = new ()) //Task 12
            //{

            //    // создаем представление
            //    db.Database.ExecuteSqlRaw(@"CREATE VIEW View_OrderViewModel AS 
            //                                SELECT c.Name AS CustomerName, o.OrderId AS OrderId, o.TotalAmount AS TotalAmount   
            //                                FROM Customers c
            //                                INNER JOIN Orders o on o.CustomerId = c.CustomerId
            //                                ");
            //    //Customer c1 = new Customer { Name = "Apple" };
            //    //Customer c2 = new Customer { Name = "Samsung" };
            //    //Customer c3 = new Customer { Name = "Huawei" };
            //    //db.Customers.AddRange(c1, c2, c3);
            //    //Order p1 = new Order {  Customer = c1, TotalAmount = 5 };
            //    //Order p2 = new Order { Customer = c1, TotalAmount = 4 };
            //    //Order p3 = new Order { Customer = c2, TotalAmount = 3 };
            //    //Order p4 = new Order { Customer = c2, TotalAmount = 5 };
            //    //Order p5 = new Order { Customer = c3, TotalAmount = 7 };
            //    //db.Orders.AddRange(p1, p2, p3, p4, p5);
            //    //db.SaveChanges();
            //}

            //using (ApplicationDbContext db = new ())
            //{
            //    // обращаемся к представлению
            //    var CustomerOrders = db.OrderViewModel.ToList();
            //    foreach (var item in CustomerOrders)
            //    {
            //        Console.WriteLine($"Customer: {item.CustomerName} Models: {item.OrderId} Sum: {item.TotalAmount}");
            //    }
            //}

            //using(ApplicationDbContext context = new()) //Task 13
            //{
            //var user = context.Employee.FirstOrDefault();
            //if (user != null)
            //{
            //    user.Name = "Bob";
            //    // сохраняем изменения
            //    context.SaveChanges();

            //    // еще раз изменяем
            //    user.Name = "Sam";
            //    // сохраняем изменения
            //    context.SaveChanges();

            //    Console.WriteLine(user.Name);

            //    var userEntry = context.Entry(user);
            //    var createdAt = userEntry.Property<DateTime>("PeriodStart").CurrentValue;
            //    var deletedAt = userEntry.Property<DateTime>("PeriodEnd").CurrentValue;
            //    Console.WriteLine($"пользователь {user.Name}");
            //    Console.WriteLine($"Дата создания: {createdAt}");
            //    Console.WriteLine($"Дата удаления {deletedAt}");
            //}

            //    var history = context.Employee.TemporalAll()
            //    .Where(u => u.EmployeeId == 1)
            //    .OrderBy(e => EF.Property<DateTime>(e, "PeriodStart"))
            //    .Select(u => new
            //    {
            //        User = u,
            //        Start = EF.Property<DateTime>(u, "PeriodStart"),
            //        End = EF.Property<DateTime>(u, "PeriodEnd")
            //    }).ToList();
            //    Console.WriteLine("История по пользователю с id=1");
            //    foreach (var item in history)
            //    {
            //        Console.WriteLine($"{item.User.Name} from {item.Start} to {item.End}");
            //    }
            //}
        }
        public class CustomLoggerProvider : ILoggerProvider
        {
            public ILogger CreateLogger(string categoryName)
            {
                return new CustomLogger();
            }

            public void Dispose()
            {
                // Cleanup logic, if needed
            }
        }

        public class CustomLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return logLevel == LogLevel.Information;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                if (!IsEnabled(logLevel))
                    return;

                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine($"[{DateTime.Now}] [{logLevel}] {formatter(state, exception)}");
                }
                //File.AppendAllText("log.txt", formatter(state, exception));
                //Console.WriteLine(formatter(state, exception));
                //Log levels
            }


        }

            
    }
}





