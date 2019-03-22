namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Homework> Homeworks { get; set; } 
        DbSet<Resource> Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=StudentSystem;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(x => x.StudentId);

            modelBuilder.Entity<Student>()
                .HasMany(x => x.Courses)
        }
    }
}
