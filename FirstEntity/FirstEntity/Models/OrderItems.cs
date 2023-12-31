﻿using System.ComponentModel.DataAnnotations;

public class OrderItems
{
    [Key]
    public int OrderItemId { get; set; }
    
    public int ProductId { get; set; }  
    public Product Product { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }
}
