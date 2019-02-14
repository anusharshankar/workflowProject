using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowProject.Models
{
    public class WorkflowContext : DbContext
    {
        public WorkflowContext(DbContextOptions<WorkflowContext> options) : base(options)
        {
        }

        public DbSet<Policy> Policies { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<Output> Outputs { get; set; }
        public DbSet<Incident> Incidents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Procedure>().ToTable("Procedure");
            modelBuilder.Entity<Process>().ToTable("Process");
            modelBuilder.Entity<Action>().ToTable("Action");
            modelBuilder.Entity<Input>().ToTable("Input");
            modelBuilder.Entity<Output>().ToTable("Output");
            modelBuilder.Entity<Incident>().ToTable("Incident");

        }

        //public DbSet<Policy> Policy { get; set; }
    }
}
