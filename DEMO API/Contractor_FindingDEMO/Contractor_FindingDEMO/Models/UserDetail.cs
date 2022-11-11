using System;
using System.Collections.Generic;

namespace Contractor_FindingDEMO.Models;

public partial class UserDetail
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? TypeUser { get; set; }

    public string? Gender { get; set; }

    public string MailId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long PhoneNumber { get; set; }

    public string? StateName { get; set; }

    public string? CityName { get; set; }

    public virtual CityName? CityNameNavigation { get; set; }

    public virtual Gender? GenderNavigation { get; set; }

    public virtual StateName? StateNameNavigation { get; set; }

    public virtual TypeUser? TypeUserNavigation { get; set; }
}
