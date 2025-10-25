using System;
using System.Collections.Generic;

namespace EmailDBlogin.Models;

public partial class UserTbl
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Add { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
