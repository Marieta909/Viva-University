using System.ComponentModel.DataAnnotations;
public class CallDetail
{
    [Key]
    public int CallID { get; set; }

    public string CallerNumber { get; set; }
    public string ReceiverNumber { get; set; }
    public DateTime CallStartTime { get; set; }
    public decimal CallDuration { get; set; }

    public int? CustomerId { get; set; }

    public Customer? Customer { get; set; }
}