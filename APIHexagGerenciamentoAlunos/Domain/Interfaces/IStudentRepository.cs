using APIHexagGerenciamentoAlunos.Application.DTOs.Filters;
using APIHexagGerenciamentoAlunos.Application.Helpers;
using APIHexagGerenciamentoAlunos.Domain.Entities;

namespace APIHexagGerenciamentoAlunos.Domain.Interfaces
{
    public interface IStudentRepository
    {
        public List<Student> GetAll();
        public Paginator<Student> PaginateAll(StudentFilter filter);
        public Student GetById(Guid Id);
        public void Create(Student student);
        public void Update(Student student);
        public void Delete(Student student);
        public void Enroll(Student student, Course course);
    }
}
