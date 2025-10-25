using System;
using System.Collections.Generic;

namespace DBfirstCORE.Models;

public partial class EmpTbl
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public int Salary { get; set; }
}
