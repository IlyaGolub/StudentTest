using Microsoft.AspNetCore.Mvc;
using StudentsTest.Entities;
using StudentsTest.Services;
using System;
using System.Threading.Tasks;

namespace StudentsTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentServices studentService;
        public StudentsController(IStudentServices studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await studentService.GetAllStudents();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await studentService.GetStudentById(id);
                if (result != null) return Ok(result);
                else return Ok("Данного студента не существует");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("deleteById/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var student = await studentService.GetStudentById(id);
                if (student == null) return Ok("Данного студента не существует");
                await studentService.DeleteStudent(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // POST api/<StudentsController>
        [HttpPost("createOrUpdate")]
        public async Task<IActionResult> CreateOrUpdateStudent([FromBody] StudentDTO student)
        {
            try
            {
                var result = await studentService.CreateOrUpdateStudent(student);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
