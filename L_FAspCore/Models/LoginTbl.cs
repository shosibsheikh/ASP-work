using System;
using System.Collections.Generic;

namespace L_FAspCore.Models;

public partial class LoginTbl
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Salary { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
