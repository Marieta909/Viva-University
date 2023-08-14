using System.ComponentModel.DataAnnotations;

public class CancelledOrder
{
    [Key]
    public int Id { get; set; }
    public Order Order { get; set; }
}
