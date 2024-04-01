using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class CustomerDetail
{
    public int Cid { get; set; }

    public string? Cname { get; set; }

    public string? Cemail { get; set; }

    public string? Cphone { get; set; }

    public string? Address { get; set; }

   // public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
