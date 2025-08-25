using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Account
{
    public int Id { get; set; }

    public int? PhoneNumber { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual Role RoleNavigation { get; set; } = null!;
}
