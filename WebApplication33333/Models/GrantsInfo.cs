using System;
using System.Collections.Generic;

namespace WebApplication33333;

public partial class GrantsInfo
{
    public string GrantName { get; set; } = null!;

    public long BanclorGrantValue { get; set; }

    public long MasterGrantValue { get; set; }

    public long AspirantGrantValue { get; set; }

    public int? GrantNameId{ get; set; }
}
