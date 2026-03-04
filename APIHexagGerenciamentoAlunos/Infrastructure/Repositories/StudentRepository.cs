using APIHexagGerenciamentoAlunos.Application.DTOs.Filters;
using APIHexagGerenciamentoAlunos.Application.Helpers;
using APIHexagGerenciamentoAlunos.Domain.Entities;
using APIHexagGerenciamentoAlunos.Domain.Interfaces;
using APIHexagGerenciamentoAlunos.Infrastructure.Data;

namespace APIHexagGerenciamentoAlunos.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public readonly AppDbcontext _database;
        public StudentRepository(AppDbcontext context)
        {
            _database = context;
        }

        public void Create(Student student)
        {
            _database.Students.Add(student);
            _database.SaveChanges();
        }

        public void Delete(Student student)
        {
            _database.Students.Remove(student);
            _database.SaveChanges();
        }

        public void Enroll(Student student, Course course)
        {
            student.CourseId = course.Id;

            _database.Students.Update(student);
            _database.SaveChanges();
        }

        public List<Student> GetAll()
        {
            List<Student> list = _database.Students
                                  .Select(stud => stud)
                                  .ToList();
            return list;
        }

        public Paginator<Student> PaginateAll(StudentFilter filter)
        {
            var query = _database.Students
                    .Select(studs => studs)
                    .Where(studs => studs.RemovedAt == null);

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(stud => stud.FirstName.Contains(filter.Name));
            }

            List<Student> data = query
                .Skip((filter.Page - 1) * filter.ItensPerPage)
                .Take(filter.ItensPerPage)
                .ToList();

            int totalItems = query.Count();
            decimal toTotalPages = totalItems / filter.ItensPerPage;
            int totalPages = (int)Math.Ceiling(toTotalPages);

            return new Paginator<Student>(totalPages, totalItems, data, filter.ItensPerPage);
        }

        public Student GetById(Guid Id)
        {
            return _database.Students.Select(stud => stud).Where(stud => stud.Id == Id).FirstOrDefault();
        }

        public void Update(Student student)
        {
            _database.Students.Update(student);
            _database.SaveChanges();
        }
    }
}
