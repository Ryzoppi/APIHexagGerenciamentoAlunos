using APIHexagGerenciamentoAlunos.Domain.Entities;

namespace APIHexagGerenciamentoAlunos.Domain.Interfaces
{
    public interface ICourseRepository
    {
        void Create(Course course);
        void Delete(Course course);
        void Update(Course course);
        Course GetById(Guid id);
        List<Course> GetAll();
    }
}
