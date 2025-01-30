using System;
using System.Collections.Generic;

namespace Multi_Tenenant.Models;

public partial class User
{
    public int UserId { get; set; }

    public int TenantId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? UserRole { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<HiringManager> HiringManagers { get; set; } = new List<HiringManager>();

    public virtual Tenant Tenant { get; set; } = null!;
}
