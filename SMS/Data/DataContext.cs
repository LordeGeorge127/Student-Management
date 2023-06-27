using Microsoft.EntityFrameworkCore;
using SMS.Models;

namespace SMS.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<Student> students { get; set; }
        public DbSet<parents> parents { get; set; }
  
        public DbSet<Address> Addresses { get; set; }

        public DbSet<StudentParent> studentParents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentParent>()
                .HasKey(pc => new { pc.StudentId, pc.ParentId });
            modelBuilder.Entity<StudentParent>()
                .HasOne(p => p.student)
                .WithMany(pc => pc.studentParents)
                .HasForeignKey(c => c.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<StudentParent>()
                .HasOne(p => p.parents)
                .WithMany(pc => pc.studentParents)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull);


        }

    }
}
