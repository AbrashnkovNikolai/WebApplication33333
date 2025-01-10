using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NpgsqlTypes;

namespace WebApplication33333;

public partial class Faculty
{
    public string Faculty1 { get; set; } = null!;

    public string GroupName { get; set; } = null!;
    
    public long GroupId{ get; set; }
     public int YearOfAdmission { get; set; }




    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
