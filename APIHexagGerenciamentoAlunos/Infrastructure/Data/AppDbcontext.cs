using APIHexagGerenciamentoAlunos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace APIHexagGerenciamentoAlunos.Infrastructure.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(stud => stud.Id);

            modelBuilder.Entity<Course>()
                .HasKey(course => course.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
