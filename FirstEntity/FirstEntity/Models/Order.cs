using System.ComponentModel.DataAnnotations;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    [Required]
    [MaxLength(50)]
    public DateTime OrderDate { get; set; }

    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    [Required]
    [MaxLength(11)]
    public decimal TotalAmount { get; set; }
    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string? Status { get; set; }

    public IList<OrderItems> OrderItems { get; set; }
}
