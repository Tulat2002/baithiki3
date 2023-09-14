using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Baithithuchanh.Data;
using Baithithuchanh.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Baithithuchanh.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext db;
        public EmployeesController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = db.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet("Get")]
        public IActionResult GetById(int id)
        {
            try
            {
                var employees = db.Employees.SingleOrDefault(po => po.EmployeeId == id);
                if (employees != null)
                {
                    return Ok(employees);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("Create")]
        public IActionResult Create(EmployeeMD employeeMD)
        {
            try
            {
                var employees = new Employee
                {
                    EmployeeName = employeeMD.EmployeeName,
                    EmployeeDOB = employeeMD.EmployeeDOB,
                    EmployeeDepartment = employeeMD.EmployeeDepartment
                };
                db.Add(employees);
                db.SaveChanges();
                return Ok(employees);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, EmployeeMD employeeMD)
        {
            try
            {
                var employees = db.Employees.SingleOrDefault(po => po.EmployeeId == id);
                if (employees != null)
                {
                    employees.EmployeeName = employeeMD.EmployeeName;
                    employees.EmployeeDOB = employeeMD.EmployeeDOB;
                    employees.EmployeeDepartment = employeeMD.EmployeeDepartment;
                    db.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var employees = db.Employees.SingleOrDefault(po => po.EmployeeId == id);
            if (employees != null)
            {
                db.Remove(employees);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

