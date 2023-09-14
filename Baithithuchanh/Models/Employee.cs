using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baithithuchanh.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(255)]
        public string EmployeeName { get; set; } = null!;

        [Required]
        public DateTime EmployeeDOB { get; set; }

        [Required]
        [StringLength(255)]
        public string EmployeeDepartment { get; set; } = null!;

        [Required]
        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; } = null!;
    }
}

