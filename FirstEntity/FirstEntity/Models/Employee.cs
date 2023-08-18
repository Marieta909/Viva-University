using System.ComponentModel.DataAnnotations;

public class Employee
{
    [Key]
    public int EmployeeId { get; }
    public string Name { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
}
