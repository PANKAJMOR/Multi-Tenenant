using System;
using System.Collections.Generic;

namespace Multi_Tenenant.Models;

public partial class Milestone
{
    public int MilestoneId { get; set; }

    public int CandidateId { get; set; }

    public string Stage { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;
}
