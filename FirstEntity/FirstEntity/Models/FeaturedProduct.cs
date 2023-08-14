using System.ComponentModel.DataAnnotations;

public class FeaturedProduct
{
    [Key]
    public int ProductId1 { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public string Name { get; set; }
}