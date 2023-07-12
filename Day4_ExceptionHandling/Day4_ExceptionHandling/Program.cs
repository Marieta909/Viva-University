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

//class Subscriber
//{
//    public string phoneNum;
//    public decimal balance;
//    public bool isInRoaming;
//    public bool isServiceActive;
//    DateTime expirationDate;

//    public Subscriber(string phoneNum, decimal balance, bool isInRoaming, DateTime expirationDate, bool isServiceActive)
//    {
//        this.phoneNum = phoneNum;
//        this.balance = balance;
//        this.isInRoaming = isInRoaming;
//        this.expirationDate = expirationDate;
//        this.isServiceActive = isServiceActive;
//    }
//}


Subscriber subscriber = new("123456789", 150, false, DateTime.Now.AddDays(4), false);
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
                throw new ServiceActivationException("Minimum required expiration date not met.", "Extend expiration date to at least 10 days in the future.");
            }

            if (IsInRoaming)
            {
                throw new ServiceActivationException("Subscriber is in roaming.", "Disable roaming to activate the service.");
            }

            if (IsServiceActive)
            {
                throw new ServiceActivationException("Service is already active.", "Deactivate the existing service before activating a new one.");
            }

            decimal requiredBalance = 100; 
            if (Balance < requiredBalance)
            {
                decimal additionalBalanceRequired = requiredBalance - Balance;
                throw new InsufficientBalanceException("Insufficient balance.", "Add $" + additionalBalanceRequired + " to your account for service activation.");
            }

            IsServiceActive = true;
            Console.WriteLine("Service activated successfully!");
        }
        catch (ServiceActivationException ex)
        {
            Console.WriteLine("Service activation failed: " + ex.Message);
            Console.WriteLine("Resolution: " + ex.Resolution);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred during service activation: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Service activation process completed.");
        }
    }
}

