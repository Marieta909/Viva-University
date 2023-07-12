////-------------------Task 1 - File Processing with Exception Handling

using System.Runtime.Serialization;

[Serializable]
internal class ServiceActivationException : Exception
{
    public ServiceActivationException()
    {
    }

    public ServiceActivationException(string? message, string v) : base(message)
    {
    }

    public ServiceActivationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ServiceActivationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public object Solution { get; internal set; }
}