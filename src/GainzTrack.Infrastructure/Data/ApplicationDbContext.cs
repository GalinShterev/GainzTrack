using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GainzTrack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using GainzTrack.Infrastructure.Identity;

namespace GainzTrack.Infrastructure.Data

{
    public class ApplicationDbContext : IdentityDbContext<IdentityApplicationUser>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<MainUser> MainUsers { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<WorkoutDay> WorkoutDays { get; set; }
        public DbSet<WorkoutRoutine> WorkoutRoutines { get; set; }
        public DbSet<AchievementUser> AchievementUsers { get; set; }
        public DbSet<ExerciseWorkoutDay>ExerciseWorkoutDays{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<WorkoutRoutine>().HasOne(b => b.Creator)
               .WithMany(b => b.WorkoutRoutines)
               .HasForeignKey(b => b.CreatorId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<WorkoutRoutine>().HasMany(b => b.WorkoutDays)
                .WithOne(b => b.WorkoutRoutine)
                .HasForeignKey(b => b.WorkoutRoutineId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<WorkoutDay>().HasMany(b => b.ExerciseWorkoutDay)
                .WithOne(b => b.WorkoutDay)
                .HasForeignKey(b => b.WorkoutDayId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Exercise>().HasMany(b => b.ExerciseWorkoutDays)
               .WithOne(b => b.Exercise)
               .HasForeignKey(b => b.ExerciseId)
               .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(builder);
        }

    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath("C:\\Users\\galio\\Desktop\\GainzTrack-Project\\GainzTrack\\src\\GainzTrack.Web")
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new ApplicationDbContext(builder.Options);
        }
    }
}
