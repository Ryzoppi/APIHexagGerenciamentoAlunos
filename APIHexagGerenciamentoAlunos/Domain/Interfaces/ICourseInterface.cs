using APIHexagGerenciamentoAlunos.Domain.Entities;
using APIHexagGerenciamentoAlunos.Application.DTOs;

namespace APIHexagGerenciamentoAlunos.Application.Interfaces
{
    public interface ICourseService
    {
        void CreateCourse(CourseDTO dto);
        void UpdateCourse(Guid id, CourseDTO dto);
        void DeleteCourse(Guid id);
        Course GetById(Guid id);
        List<Course> ListCourses();
    }
}
