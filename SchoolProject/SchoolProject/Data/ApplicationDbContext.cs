using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;

namespace SchoolProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Marks> marks { get; set; }
        public DbSet<Library> libraryBooks { get; set; }

        public DbSet<Grade> grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasOne(x => x.Marks).WithOne(z => z.Student).HasForeignKey<Marks>(x => x.studentId);
            modelBuilder.Entity<Library>().HasOne(x => x.Student).WithMany(z => z.Libraries).HasForeignKey(x => x.StudentId);
            modelBuilder.Entity<Student>().HasOne(x => x.Grade).WithMany(z => z.Students).HasForeignKey(x=>x.GradeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
