using System;
using System.Collections.Generic;

namespace Multi_Tenenant.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public int TenantId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string ContactEmail { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;
}
