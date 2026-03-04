using APIHexagGerenciamentoAlunos.Application.DTOs;
using APIHexagGerenciamentoAlunos.Application.DTOs.Filters;
using APIHexagGerenciamentoAlunos.Domain.Entities;
using APIHexagGerenciamentoAlunos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIHexagGerenciamentoAlunos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            this._service = service;
        }

        [HttpGet("ListStudents")]
        public IActionResult ListStudents()
        {
            try
            {
                List<Student> list = this._service.ListStudents();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPost("Paginate")]
        public IActionResult Paginate([FromBody] StudentFilter filter)
        {
            try
            {
                var result = this._service.Paginate(filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent([FromBody] StudentDTO dto)
        {
            try
            {
                this._service.CreateStudent(dto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] Guid id)
        {
            try
            {
                Student student = this._service.GetById(id);

                if (student == null)
                    return NotFound(new { message = "Estudante não encontrado." });

                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateStudent/{id}")]
        public IActionResult UpdateStudent(Guid id, [FromBody] StudentDTO dto)
        {
            try
            {
                this._service.UpdateStudent(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(Guid id)
        {
            try
            {
                this._service.DeleteStudent(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("EnrollStudent")]
        public IActionResult EnrollStudent([FromBody] EnrollDTO dto)
        {
            try
            {
                _service.EnrollStudent(dto.StudentId, dto.CourseId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
