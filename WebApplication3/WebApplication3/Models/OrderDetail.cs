using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public int Cid { get; set; }

    public int ProductId { get; set; }

    public int? Quantity { get; set; }

    public int StatusId { get; set; }

    //public virtual CustomerDetail CidNavigation { get; set; } = null!;
}
