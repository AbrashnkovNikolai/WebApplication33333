using System;
using System.Collections.Generic;

namespace WebApplication33333;

public partial class Student
{
    public int Id{ get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentSurname { get; set; } = null!;

    public string StudentFatherName { get; set; } = null!;

    public long Semester { get; set; }

    public string Degree { get; set; } = null!;

    public long? Group { get; set; }

    public virtual Faculty? GroupNavigation { get; set; }
}
