using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnet_with_react_back_end.Models;

public partial class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    public int? DepartmentId { get; set; }

    public string? EmployeeName { get; set; }

    public DateTime? DateOfJoining { get; set; }

    public string? PhotoFileName { get; set; }
}
