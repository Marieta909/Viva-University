////-------------------Task 1 - File Processing with Exception Handling

using System.Runtime.Serialization;

[Serializable]
internal class InsufficientBalanceException : ServiceActivationException
{
    public string v1;
    public string v2;
    //public string CustomMessage { get; set; }

    public InsufficientBalanceException()
    {
        
    }

    public string CustomMessage { get; set; }

    public InsufficientBalanceException(string message, string customMessage) : base(message, customMessage)
    {
        CustomMessage = customMessage;
    }


    //public InsufficientBalanceException(string v1, string v2)
    //{
    //    this.v1 = v1;
    //    this.v2 = v2;
    //}

    public InsufficientBalanceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected InsufficientBalanceException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    
}