using APIHexagGerenciamentoAlunos.Application.DTOs;
using APIHexagGerenciamentoAlunos.Application.Interfaces;
using APIHexagGerenciamentoAlunos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIHexagGerenciamentoAlunos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet("ListCourses")]
        public IActionResult ListCourses()
        {
            try
            {
                List<Course> list = _service.ListCourses();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] Guid id)
        {
            try
            {
                Course course = _service.GetById(id);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("CreateCourse")]
        public IActionResult CreateCourse([FromBody] CourseDTO dto)
        {
            try
            {
                _service.CreateCourse(dto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("UpdateCourse/{id}")]
        public IActionResult UpdateCourse(Guid id, [FromBody] CourseDTO dto)
        {
            try
            {
                _service.UpdateCourse(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("DeleteCourse/{id}")]
        public IActionResult DeleteCourse(Guid id)
        {
            try
            {
                _service.DeleteCourse(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}