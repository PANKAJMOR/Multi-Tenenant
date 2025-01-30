using System;
using System.Collections.Generic;

namespace Multi_Tenenant.Models;

public partial class Tenant
{
    public int TenantId { get; set; }

    public string TenantName { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

    public virtual ICollection<HiringManager> HiringManagers { get; set; } = new List<HiringManager>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

    public virtual ICollection<TimeZone> TimeZones { get; set; } = new List<TimeZone>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
