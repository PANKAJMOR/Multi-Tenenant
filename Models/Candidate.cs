using System;
using System.Collections.Generic;

namespace Multi_Tenenant.Models;

public partial class Candidate
{
    public int CandidateId { get; set; }

    public int TenantId { get; set; }

    public string CandidateName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<CandidateHiringManager> CandidateHiringManagers { get; set; } = new List<CandidateHiringManager>();

    public virtual ICollection<Milestone> Milestones { get; set; } = new List<Milestone>();

    public virtual Tenant Tenant { get; set; } = null!;
}
