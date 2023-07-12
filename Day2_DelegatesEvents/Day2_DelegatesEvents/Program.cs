////------------------Task 1 - Delegate Invocation
//Console.OutputEncoding = System.Text.Encoding.UTF8;

//PrintDelegate printDelegate = PrintToConsole;

//printDelegate.Invoke("Բարի գալուստ Viva MTS!");
//static void PrintToConsole(string message)
//{
//    Console.WriteLine(message);
//}

//public delegate void PrintDelegate(string message);

//-----------------------------------------------------------------

////--------------Task 2 - Event Handling with Delegates

//Button button = new Button();
//button.ButtonClickEvent += () =>
//{
//    Console.WriteLine("Button Is Clicked!");
//};

//Console.WriteLine("Press any key to simulate button click...");
//Console.ReadKey();

//Console.WriteLine();
//button.Press();

//Console.ReadLine();

//class Button
//{
//    public delegate void ButtonClickDelegate();
//    public event ButtonClickDelegate ButtonClickEvent;

//    public void Press()
//    {
//        ButtonClickEvent?.Invoke();
//    }
//}



////--------------Task 3 - Anonymous Method

//OperationDelegate operation =  (int a, int b) =>
//{
//    return a + b;
//};

//int additionResult = operation(10, 3);
//Console.WriteLine("Addition Result: " + additionResult);

//operation =  (int a, int b) =>
//{
//    return a - b;
//};

//int subtractionResult = operation(5, 3);
//Console.WriteLine("Subtraction Result: " + subtractionResult);

//public delegate int OperationDelegate(int a, int b);


////------------------Task 4 - Lambda Expression

//delegate int ComparisonDelegate(int a, int b);

//class Program
//{
//    static void Main(string[] args)
//    {
//        ComparisonDelegate comparison = (a, b) =>
//        {
//            return a - b;
//        };

//        int result1 = comparison(5, 3);
//        Console.WriteLine("Comparison Result 1: " + result1);

//        int result2 = comparison(3, 5);
//        Console.WriteLine("Comparison Result 2: " + result2);

//        int result3 = comparison(5, 5);
//        Console.WriteLine("Comparison Result 3: " + result3);
//    }
//}

//-------------------Task 5 - Refill Event Handling
Console.OutputEncoding = System.Text.Encoding.UTF8;

BalanceRefillProcessor processor = new();
processor.BalanceRefillEvent += (phoneNumber, refillAmount) =>
{
    Console.WriteLine($"{phoneNumber} հեռախոսահամարը վերալիցքավորվել է {refillAmount} դրամով։");
};


string phoneNumber = "+37494999999";
decimal refillAmount = 100.0m;
processor.ReceiveBalanceRefillTrigger(phoneNumber, refillAmount);

Console.ReadLine();

class BalanceRefillProcessor
{ 
    public BalanceRefillDelegate? BalanceRefillEvent;
    public void ReceiveBalanceRefillTrigger(string phoneNumber, decimal refillAmount)
    {
        BalanceRefillEvent?.Invoke(phoneNumber, refillAmount);
    }
}

delegate void BalanceRefillDelegate(string phoneNumber, decimal refillAmount);