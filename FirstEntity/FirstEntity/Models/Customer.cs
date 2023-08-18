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
    public DateTime Birthdate { get; set; }

    public bool IsDeleted { get; set; }

    public decimal AVGcalls { get; set; }

    public ICollection<Order>? Orders { get; set; }
    public ICollection<CallDetail>? CallDetails { get; set; }

    [Timestamp]
    public byte[]? Timestamp { get; set; }
}