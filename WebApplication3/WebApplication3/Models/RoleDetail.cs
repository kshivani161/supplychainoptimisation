using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class RoleDetail
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    //public virtual ICollection<UserDetail> UserDetails { get; set; } = new List<UserDetail>();
}
