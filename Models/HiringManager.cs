using System;
using System.Collections.Generic;

namespace Multi_Tenenant.Models;

public partial class HiringManager
{
    public int HiringManagerId { get; set; }

    public int TenantId { get; set; }

    public int UserId { get; set; }

    public string ManagerName { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<CandidateHiringManager> CandidateHiringManagers { get; set; } = new List<CandidateHiringManager>();

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
