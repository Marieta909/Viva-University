using System.ComponentModel.DataAnnotations;
public class NewCustomer
{
    [Key]
    public int NewCustomerId { get; set; }
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
}