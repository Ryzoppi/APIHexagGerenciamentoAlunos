using APIHexagGerenciamentoAlunos.Application.DTOs;
using APIHexagGerenciamentoAlunos.Application.DTOs.Filters;
using APIHexagGerenciamentoAlunos.Application.Helpers;
using APIHexagGerenciamentoAlunos.Domain.Entities;
using APIHexagGerenciamentoAlunos.Domain.Interfaces;

namespace APIHexagGerenciamentoAlunos.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly ICourseRepository _courseRepository;
        public StudentService(IStudentRepository repository, ICourseRepository courseRepository)
        {
            this._repository = repository;
            this._courseRepository = courseRepository;
        }

        public void CreateStudent(StudentDTO studentDto)
        {
            try
            {
                Student newStudent = new Student();
                
                if (studentDto.FirstName == null)
                {
                    throw new Exception("FirstName é obrigatório");
                }

                newStudent.FirstName = studentDto.FirstName;
                newStudent.LastName = studentDto.LastName;
                newStudent.Email = studentDto.Email;

                newStudent.UpdatePassword("asasass");

                _repository.Create(newStudent);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteStudent(Guid Id)
        {
            try
            {
                Student stud = _repository.GetById(Id);
                if (stud == null) throw new Exception("Estudante não existe");

                _repository.Delete(stud);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Student GetById(Guid id)
        {
            try
            {
                Student user = _repository.GetById(id);

                if (user == null)
                {
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Paginator<StudentEmail> Paginate(StudentFilter filter)
        {
            try
            {
                filter.Page = (filter.Page <= 0) ? 1 : filter.Page;
                filter.ItensPerPage = (filter.ItensPerPage <= 0) ? 10 : filter.ItensPerPage;

                Paginator<Student> paginator = _repository.PaginateAll(filter);

                Paginator<StudentEmail> newPaginator = new Paginator<StudentEmail>(
                    paginator.TotalPages,
                    paginator.TotalItems,
                    new List<StudentEmail>(),
                    paginator.PageCount
                );

                if (paginator.TotalItems == 0)
                {
                    return newPaginator;
                }

                foreach (Student stud in paginator.Data)
                {
                    StudentEmail studEmail = new StudentEmail();
                    studEmail.Name = stud.FirstName + " " + stud.LastName;
                    studEmail.Email = stud.Email;
                    newPaginator.Data.Add(studEmail);
                }

                return newPaginator;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Student> ListStudents()
        {
            try
            {
                List<Student> list = _repository.GetAll();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateStudent(Guid Id, StudentDTO dto)
        {
            try
            {
                if (!dto.Email.EndsWith("@faculdade.edu"))
                    throw new Exception("Email deve ter final @faculdade.edu");
                if (string.IsNullOrEmpty(dto.FirstName))
                    throw new Exception("Primeiro nome é obrigatório.");
                if (dto.FirstName.Length > 50)
                    throw new Exception("Limite máximo de 50 caracteres");


                Student stud = _repository.GetById(Id);
                if (stud == null) throw new Exception("Estudante não existe");
                stud.FirstName = dto.FirstName;
                stud.LastName = dto.LastName;
                stud.Email = dto.Email;

                _repository.Update(stud);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public void EnrollStudent(Guid studentId, Guid courseId)
        {
            try
            {
                Student student = _repository.GetById(studentId);
                if (student == null)
                    throw new Exception("Estudante não existe.");

                if (student.CourseId != null)
                    throw new Exception("Estudante já está matriculado em um curso.");

                Course course = _courseRepository.GetById(courseId);
                if (course == null)
                    throw new Exception("Curso não existe.");

                _repository.Enroll(student, course);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

public class StudentEmail
{
    public string Email { get; set; }
    public string Name { get; set; }
}