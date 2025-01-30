using System;
using System.Collections.Generic;

namespace Multi_Tenenant.Models;

public partial class CandidateHiringManager
{
    public int CandidateId { get; set; }

    public int HiringManagerId { get; set; }

    public DateTime? AssignedDate { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;

    public virtual HiringManager HiringManager { get; set; } = null!;
}
