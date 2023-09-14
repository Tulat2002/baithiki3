using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baithithuchanh.Models
{
    public class ProjectEmployee
    {
        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }

        public string Tasks { get; set; }

        public virtual Employee? Employee { get; set; }

        public virtual Project? Project { get; set; }
    }
}

