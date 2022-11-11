using System;
using System.Collections.Generic;

namespace Contractor_FindingDEMO.Models;

public partial class Gender
{
    public int GenderId { get; set; }

    public string GenderName { get; set; } = null!;

    public virtual ICollection<UserDetail> UserDetails { get; } = new List<UserDetail>();
}
