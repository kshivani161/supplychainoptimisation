using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class ProductDetail
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public decimal? ProductCost { get; set; }

    public int? Quantity { get; set; }
}
