using System;
using System.Collections.Generic;

namespace Multi_Tenenant.Models;

public partial class TimeZone
{
    public int TimeZoneId { get; set; }

    public int TenantId { get; set; }

    public string TimeZoneName { get; set; } = null!;

    public int OffsetHours { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;
}
