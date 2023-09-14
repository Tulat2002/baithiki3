using System;
using System.ComponentModel.DataAnnotations;

namespace Baithithuchanh.Data
{
	public class ProjectMD
	{
        [Required]
        [StringLength(255)]
        public string ProjectName { get; set; } = null!;

        [Required]
        public DateTime ProjectStartDate { get; set; }

        public DateTime? ProjectEndDate { get; set; }

    }
}

