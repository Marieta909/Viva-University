using System.ComponentModel.DataAnnotations;

public class BestSellerProduct
{
    [Key]
    public int ProductId2 { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public string Name { get; set; }
}