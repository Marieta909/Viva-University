using System.ComponentModel.DataAnnotations;

public class OrderViewModel
{
    public int OrderId { get; set; }
    public string? CustomerName { get; set; }
    public decimal TotalAmount { get; set; }
}
