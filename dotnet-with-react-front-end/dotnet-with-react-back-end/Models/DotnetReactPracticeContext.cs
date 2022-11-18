using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dotnet_with_react_back_end.Models;

public partial class DotnetReactPracticeContext : DbContext
{
    public DotnetReactPracticeContext(DbContextOptions<DotnetReactPracticeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity
                .ToTable("Department");

            entity.Property(e => e.DepartmentId).ValueGeneratedOnAdd();
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity
                .ToTable("Employee");

            entity.Property(e => e.DateOfJoining).HasColumnType("date");
            entity.Property(e => e.EmployeeId).ValueGeneratedOnAdd();
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PhotoFileName)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
