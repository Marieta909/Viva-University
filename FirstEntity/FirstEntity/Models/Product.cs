using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    [MaxLength(50)]
    public string? ProductName { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative.")]
    public int StockQuantity { get; set; }

    public string? Category {get; set; }

    public ProductDetails Details { get; set; }

    public IList<OrderItems> OrderItems { get; set; }

}
