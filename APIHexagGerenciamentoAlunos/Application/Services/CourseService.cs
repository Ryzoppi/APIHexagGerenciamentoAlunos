using APIHexagGerenciamentoAlunos.Application.DTOs;
using APIHexagGerenciamentoAlunos.Application.Interfaces;
using APIHexagGerenciamentoAlunos.Domain.Entities;
using APIHexagGerenciamentoAlunos.Domain.Interfaces;

namespace APIHexagGerenciamentoAlunos.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public void CreateCourse(CourseDTO dto)
        {
            try
            {
                if (string.IsNullOrEmpty(dto.Name))
                    throw new Exception("Nome do curso é obrigatório.");

                if (string.IsNullOrEmpty(dto.Description))
                    throw new Exception("Descrição do curso é obrigatória.");

                Course course = new Course()
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Description = dto.Description,
                    CreatedAt = DateTime.UtcNow
                };

                _repository.Create(course);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateCourse(Guid id, CourseDTO dto)
        {
            try
            {
                if (string.IsNullOrEmpty(dto.Name))
                    throw new Exception("Nome do curso é obrigatório.");

                if (string.IsNullOrEmpty(dto.Description))
                    throw new Exception("Descrição do curso é obrigatória.");

                Course course = _repository.GetById(id);

                if (course == null)
                    throw new Exception("Curso não existe.");

                course.Name = dto.Name;
                course.Description = dto.Description;

                _repository.Update(course);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCourse(Guid id)
        {
            try
            {
                Course course = _repository.GetById(id);

                if (course == null)
                    throw new Exception("Curso não existe.");

                _repository.Delete(course);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Course GetById(Guid id)
        {
            try
            {
                Course course = _repository.GetById(id);

                if (course == null)
                    throw new Exception("Curso não existe.");

                return course;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Course> ListCourses()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}