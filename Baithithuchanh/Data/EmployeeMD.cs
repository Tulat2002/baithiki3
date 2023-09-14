using System;
using System.ComponentModel.DataAnnotations;

namespace Baithithuchanh.Data
{
	public class EmployeeMD
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
    }
}

