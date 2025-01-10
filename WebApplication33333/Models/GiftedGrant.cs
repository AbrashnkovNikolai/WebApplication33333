using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication33333;

public partial class GiftedGrant
{
    [Key]public int Id{ get; set; }
    public int StudentId{ get; set; }

    public string GrantName { get; set; } = null!;

    public long? GrantValue { get; set; }

    public virtual GrantsInfo GrantNameNavigation { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
