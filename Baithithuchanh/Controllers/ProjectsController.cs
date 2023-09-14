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
    public class ProjectsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var project = _context.Projects.ToList();
            return Ok(project);
        }

        [HttpGet("{id}")]
        public IActionResult GetById (int id)
        {
            try
            {
                var projects = _context.Projects.SingleOrDefault(po => po.ProjectId == id);
                if(projects != null)
                {
                    return Ok(projects);
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

        [HttpPost]
        public IActionResult Create(ProjectMD projectMD)
        {
            try
            {
                var project = new Project
                {
                    ProjectName = projectMD.ProjectName,
                    ProjectStartDate = projectMD.ProjectStartDate,
                    ProjectEndDate = projectMD.ProjectEndDate
                };
                _context.Add(project);
                _context.SaveChanges();
                return Ok(project);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProjectMD projectMD)
        {
            try
            {
                var project = _context.Projects.SingleOrDefault(po => po.ProjectId == id);
                if(project != null)
                {
                    project.ProjectName = projectMD.ProjectName;
                    project.ProjectStartDate = projectMD.ProjectStartDate;
                    project.ProjectEndDate = projectMD.ProjectEndDate;
                    _context.SaveChanges();
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = _context.Projects.SingleOrDefault(po => po.ProjectId == id);
            if(project != null)
            {
                _context.Remove(project);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

