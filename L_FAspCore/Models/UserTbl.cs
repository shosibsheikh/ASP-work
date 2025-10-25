using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace L_FAspCore.Models;

public partial class UserTbl
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Add { get; set; } = null!;

    public string? Email { get; set; }
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}
