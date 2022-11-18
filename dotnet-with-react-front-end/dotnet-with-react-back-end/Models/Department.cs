using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnet_with_react_back_end.Models;

public partial class Department
{
    [Key]
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }
}
