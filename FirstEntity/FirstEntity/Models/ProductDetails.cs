using System.ComponentModel.DataAnnotations;

public class ProductDetails
{
    [Key]
    public int ProductDetId { get; set; } 
    public int ProductId { get; set; }
    public string Description { get; set; }
    public string Manufacturer { get; set; }

    public Product Product { get; set; }
} 