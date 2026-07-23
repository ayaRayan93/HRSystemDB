using HRSystem.Domain.Entities;
using HRSystemDB.Domain.Entities;
using HRSystemDB.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace HRSystem.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // 1. Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Human Resources", Code = "HR", Description = "Human Resources Department", IsActive = true, CreatedDate = DateTime.UtcNow },
                new Department { Id = 2, Name = "Information Technology", Code = "IT", Description = "IT Department", IsActive = true, CreatedDate = DateTime.UtcNow },
                new Department { Id = 3, Name = "Finance", Code = "FIN", Description = "Finance Department", IsActive = true, CreatedDate = DateTime.UtcNow },
                new Department { Id = 4, Name = "Marketing", Code = "MKT", Description = "Marketing Department", IsActive = true, CreatedDate = DateTime.UtcNow },
                new Department { Id = 5, Name = "Operations", Code = "OPS", Description = "Operations Department", IsActive = true, CreatedDate = DateTime.UtcNow }
            );

            // 2. Seed Positions
            modelBuilder.Entity<Position>().HasData(
                new Position { Id = 1, Title = "CEO", Grade = 1, MinSalary = 30000, MaxSalary = 50000, IsActive = true, CreatedDate = DateTime.UtcNow },
                new Position { Id = 2, Title = "Department Manager", Grade = 2, MinSalary = 20000, MaxSalary = 35000, IsActive = true, CreatedDate = DateTime.UtcNow },
                new Position { Id = 3, Title = "Senior Developer", Grade = 3, MinSalary = 15000, MaxSalary = 25000, IsActive = true, CreatedDate = DateTime.UtcNow },
                new Position { Id = 4, Title = "Developer", Grade = 4, MinSalary = 10000, MaxSalary = 18000, IsActive = true, CreatedDate = DateTime.UtcNow },
                new Position { Id = 5, Title = "Junior Developer", Grade = 5, MinSalary = 6000, MaxSalary = 10000, IsActive = true, CreatedDate = DateTime.UtcNow },
                new Position { Id = 6, Title = "HR Specialist", Grade = 4, MinSalary = 8000, MaxSalary = 15000, IsActive = true, CreatedDate = DateTime.UtcNow },
                new Position { Id = 7, Title = "Accountant", Grade = 4, MinSalary = 8000, MaxSalary = 15000, IsActive = true, CreatedDate = DateTime.UtcNow },
                new Position { Id = 8, Title = "Marketing Specialist", Grade = 4, MinSalary = 7000, MaxSalary = 14000, IsActive = true, CreatedDate = DateTime.UtcNow }
            );

            // 3. Seed Employees (We'll add users later)
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    EmployeeCode = "EMP001",
                    FirstName = "Ahmed",
                    LastName = "Mohamed",
                    Email = "ahmed.mohamed@company.com",
                    Phone = "01000000001",
                    NationalId = "12345678901234",
                    Gender = Gender.Male,
                    BirthDate = new DateTime(1985, 5, 15),
                    HireDate = new DateTime(2015, 1, 1),
                    DepartmentId = 2,
                    PositionId = 1,
                    ManagerId = null,
                    BasicSalary = 30000,
                    Allowances = 5000,
                    BankName = "National Bank",
                    AccountNumber = "1234567890",
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Employee
                {
                    Id = 2,
                    EmployeeCode = "EMP002",
                    FirstName = "Sara",
                    LastName = "Ali",
                    Email = "sara.ali@company.com",
                    Phone = "01000000002",
                    NationalId = "22345678901234",
                    Gender = Gender.Female,
                    BirthDate = new DateTime(1990, 8, 20),
                    HireDate = new DateTime(2018, 3, 15),
                    DepartmentId = 1,
                    PositionId = 2,
                    ManagerId = 1,
                    BasicSalary = 20000,
                    Allowances = 3000,
                    BankName = "National Bank",
                    AccountNumber = "1234567891",
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Employee
                {
                    Id = 3,
                    EmployeeCode = "EMP003",
                    FirstName = "Mohamed",
                    LastName = "Hassan",
                    Email = "mohamed.hassan@company.com",
                    Phone = "01000000003",
                    NationalId = "32345678901234",
                    Gender = Gender.Male,
                    BirthDate = new DateTime(1992, 3, 10),
                    HireDate = new DateTime(2019, 6, 1),
                    DepartmentId = 2,
                    PositionId = 3,
                    ManagerId = 1,
                    BasicSalary = 15000,
                    Allowances = 2000,
                    BankName = "National Bank",
                    AccountNumber = "1234567892",
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Employee
                {
                    Id = 4,
                    EmployeeCode = "EMP004",
                    FirstName = "Nadia",
                    LastName = "Ibrahim",
                    Email = "nadia.ibrahim@company.com",
                    Phone = "01000000004",
                    NationalId = "42345678901234",
                    Gender = Gender.Female,
                    BirthDate = new DateTime(1995, 11, 25),
                    HireDate = new DateTime(2020, 9, 1),
                    DepartmentId = 3,
                    PositionId = 7,
                    ManagerId = 2,
                    BasicSalary = 10000,
                    Allowances = 1500,
                    BankName = "National Bank",
                    AccountNumber = "1234567893",
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow
                }
            );

            // 4. Seed System Users
            modelBuilder.Entity<SystemUser>().HasData(
                new SystemUser
                {
                    Id = 1,
                    EmployeeId = 1,
                    Username = "ahmed.mohamed",
                    PasswordHash = "AQAAAAEAACcQAAAAE...", // Will be replaced with actual hash
                    PasswordSalt = "SaltValue...",
                    Role = UserRole.Admin,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow
                },
                new SystemUser
                {
                    Id = 2,
                    EmployeeId = 2,
                    Username = "sara.ali",
                    PasswordHash = "AQAAAAEAACcQAAAAE...",
                    PasswordSalt = "SaltValue...",
                    Role = UserRole.HR,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow
                },
                new SystemUser
                {
                    Id = 3,
                    EmployeeId = 3,
                    Username = "mohamed.hassan",
                    PasswordHash = "AQAAAAEAACcQAAAAE...",
                    PasswordSalt = "SaltValue...",
                    Role = UserRole.Manager,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow
                },
                new SystemUser
                {
                    Id = 4,
                    EmployeeId = 4,
                    Username = "nadia.ibrahim",
                    PasswordHash = "AQAAAAEAACcQAAAAE...",
                    PasswordSalt = "SaltValue...",
                    Role = UserRole.Employee,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow
                }
            );

            // 5. Seed Attendance (Last 7 days)
            var today = DateTime.Today;
            for (int i = 0; i < 7; i++)
            {
                var date = today.AddDays(-i);
                if (date.DayOfWeek != DayOfWeek.Friday && date.DayOfWeek != DayOfWeek.Saturday) // Weekend
                {
                    modelBuilder.Entity<Attendance>().HasData(
                        new Attendance
                        {
                            Id = i + 1,
                            EmployeeId = 1,
                            AttendanceDate = date,
                            CheckInTime = new TimeSpan(8, 30, 0),
                            CheckOutTime = new TimeSpan(17, 0, 0),
                            LateMinutes = 0,
                            EarlyLeaveMinutes = 0,
                            OvertimeHours = 0,
                            Status = AttendanceStatus.Present,
                            Approved = true,
                            CreatedDate = DateTime.UtcNow
                        }
                    );
                }
            }
        }
    }
}
