using System.ComponentModel.DataAnnotations;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }
    [Required]
    [MaxLength(50)]
    public string? Address { get; set; }
    [Required]
    [MaxLength(11)]
    public string? ContactNumber { get; set; }
    [Required]
    [MaxLength(100)]
    [EmailAddress]    
    public string? Email { get; set; }

    public bool IsDeleted { get; set; }

    public ICollection<Order>? Orders { get; set; }
}