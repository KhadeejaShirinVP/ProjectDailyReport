using System;
using System.Collections.Generic;

namespace Contractor_FindingDEMO.Models;

public partial class CityName
{
    public int CityId { get; set; }

    public string CityName1 { get; set; } = null!;

    public virtual ICollection<UserDetail> UserDetails { get; } = new List<UserDetail>();
}
