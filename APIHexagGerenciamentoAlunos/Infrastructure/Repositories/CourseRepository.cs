using APIHexagGerenciamentoAlunos.Domain.Entities;
using APIHexagGerenciamentoAlunos.Domain.Interfaces;
using APIHexagGerenciamentoAlunos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace APIHexagGerenciamentoAlunos.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbcontext _database;

        public CourseRepository(AppDbcontext context)
        {
            _database = context;
        }

        public void Create(Course course)
        {
            _database.Courses.Add(course);
            _database.SaveChanges();
        }

        public void Delete(Course course)
        {
            _database.Courses.Remove(course);
            _database.SaveChanges();
        }

        public void Update(Course course)
        {
            _database.Courses.Update(course);
            _database.SaveChanges();
        }

        public Course GetById(Guid id)
        {
            return _database.Courses
                     .Include(c => c.Students)
                     .FirstOrDefault(c => c.Id == id);
        }

        public List<Course> GetAll()
        {
            return _database.Courses
                     .Include(c => c.Students)
                     .ToList();
        }
    }
}