using System;
using Baithithuchanh.Models;
using Microsoft.EntityFrameworkCore;

namespace Baithithuchanh.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Employee> Employees { get; set; }

		public DbSet<Project> Projects { get; set; }

		public DbSet<ProjectEmployee> ProjectEmployee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<ProjectEmployee>()
				.HasKey(pe => new { pe.EmployeeId, pe.ProjectId });

			modelBuilder.Entity<ProjectEmployee>()
				.HasOne(pe => pe.Employee)
				.WithMany(e => e.ProjectEmployees)
				.HasForeignKey(pe => pe.EmployeeId);

			modelBuilder.Entity<ProjectEmployee>()
                .HasOne(pe => pe.Project)
                .WithMany(p => p.ProjectEmployees)
                .HasForeignKey(pe => pe.ProjectId);


            base.OnModelCreating(modelBuilder);
        }


    }
}

