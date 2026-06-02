using System;
using EngineeringMasterclass.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineeringMasterclass.Dal {
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {}

        public DbSet<Student> Students {get; set;}
        public DbSet<Assignment> Assignments {get; set;}
        public DbSet<Submission> Submissions {get; set;}

    }
}