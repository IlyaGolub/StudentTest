using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentsTest.Entities;
using StudentsTest.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<StudentsController>
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

        // GET api/<StudentsController>/5
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await studentService.GetStudentById(id);
                return Ok(result);
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
                await studentService.DeleteStudent(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
       
    }
}
