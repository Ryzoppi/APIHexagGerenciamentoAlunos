using APIHexagGerenciamentoAlunos.Application.DTOs;
using APIHexagGerenciamentoAlunos.Application.DTOs.Filters;
using APIHexagGerenciamentoAlunos.Application.Helpers;
using APIHexagGerenciamentoAlunos.Domain.Entities;

namespace APIHexagGerenciamentoAlunos.Domain.Interfaces
{
    public interface IStudentService
    {
        public List<Student> ListStudents();
        public Student GetById(Guid id);
        public Paginator<StudentEmail> Paginate(StudentFilter filter);
        public void CreateStudent(StudentDTO student);
        public void UpdateStudent(Guid id, StudentDTO student);
        public void DeleteStudent(Guid id);
        public void EnrollStudent(Guid studentId, Guid courseId);
    }
}
