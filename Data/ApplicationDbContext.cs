using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Models;

namespace WorkoutTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<ClassType> ClassTypes { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
