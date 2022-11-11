using System;
using System.Collections.Generic;

namespace Contractor_FindingDEMO.Models;

public partial class TypeUser
{
    public int Id { get; set; }

    public string UserType { get; set; } = null!;

    public DateTime? Duration { get; set; }

    public virtual ICollection<UserDetail> UserDetails { get; } = new List<UserDetail>();
}
