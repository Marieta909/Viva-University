////-------------------Task 1 - File Processing with Exception Handling

//using StreamReader sr = new("testik.txt");
//using StreamWriter sw = new("next.txt");
//try
//{
//    while (!sr.EndOfStream)
//    {
//        string readFile = sr.ReadLine();
//        Console.WriteLine(readFile);

//        sw.WriteLine(readFile?.ToUpper());

//        Console.WriteLine("The result is saved!");
//    }

//}
//catch (FileNotFoundException ex)
//{
//    Console.WriteLine($"The file could not be found: {ex.FileName}");
//}

//catch (Exception ex)
//{
//    Console.WriteLine($"The file could not be found: {ex.Message}");
//}

////------------------Task 2 - Input Validation with Exception Handling


//Console.OutputEncoding = System.Text.Encoding.UTF8;
//bool checkAge = false;
//while(true)
//{
//    try
//    {
//        Console.Write("Ներմուծեք Ձեր տարիքը` ");
//        int age = int.Parse(Console.ReadLine());

//        if (age < 18 || age > 40)
//        {
//            Console.ForegroundColor = ConsoleColor.Red;

//            throw new ArgumentException("Դուք անչափահաս եք կամ չափազանց չափահաս!");
//            //Console.ResetColor();
//        }
//        checkAge = true;
//        return age;
//    }
//    catch (FormatException)
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("Տարիքն ընդունվում է միայն թվերով։");
//        Console.ResetColor();
//    }

//    catch (ArgumentException ex)
//    {
//        Console.WriteLine(ex.Message);
//        Console.ResetColor();
//    }
//    finally
//    {
//        if (checkAge)
//        {
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine("Ձեր տարիքը հաջողությամբ մուտքագրվել է։");
//            Console.ResetColor();
//        }

//    }
//}

//------------------------Task 3: Custom Exception Handling

Console.OutputEncoding = System.Text.Encoding.UTF8;

Subscriber subscriber = new("93070113", 50, false, DateTime.Now.AddDays(12), false);
subscriber.ActivateService();
class Subscriber
{
    public string PhoneNum { get; set; }
    public decimal Balance { get; set; }
    public bool IsInRoaming { get; set; }
    public bool IsServiceActive { get; set; }
    public DateTime ExpirationDate { get; set; }

    public Subscriber(string phoneNum, decimal balance, bool isInRoaming, DateTime expirationDate, bool isServiceActive)
    {
        this.PhoneNum = phoneNum;
        this.Balance = balance;
        this.IsInRoaming = isInRoaming;
        ExpirationDate = expirationDate;
        this.IsServiceActive = isServiceActive;
    }

    public void ActivateService()
    {
        try
        {
            if (ExpirationDate - DateTime.Now <= TimeSpan.FromDays(10))
            {
                throw new ServiceActivationException("There isn't at least 10 days until expirationDate", "Extend expiration date to at least 10 days.");
            }

            if (IsInRoaming)
            {
                throw new ServiceActivationException("Subscriber is in roaming.", "If you want to activate service, turn off roaming");
            }

            if (IsServiceActive)
            {
                throw new ServiceActivationException("Service is active at the moment.", "If you want to activate new service, deactivate the existing one.");
            }

            decimal necessaryBalance = 100; 
            if (Balance < necessaryBalance)
            {
                decimal addBalance = necessaryBalance - Balance;
                throw new InsufficientBalanceException("Balance is not enough.", "Add $" + addBalance + " for service activation.");
            }

            IsServiceActive = true;
            Console.WriteLine("Service activated successfully!");
        }
        catch (ServiceActivationException ex)
        {
            Console.WriteLine($"Service activation failed: {ex.Message}" );
            Console.WriteLine($"Solution: {ex.Solution}" );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong: {ex.Message} ");
        }
        finally
        {
            if (IsServiceActive)
            {
                Console.WriteLine("Service activation process completed.");
            }
            
        }
    }
}

