using DotNetCoreWebAPIWithMongoDB.Models;
using DotNetCoreWebAPIWithMongoDB.Serivecs;
using Microsoft.AspNetCore.Mvc;


namespace DotNetCoreWebAPIWithMongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            await _studentService.CreateStudent(student);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            var students = await _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(string id)
        {
            var student = await _studentService.GetStudent(id);
            return Ok(student);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            await _studentService.UpdateStudent(student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            await _studentService.DeleteStudent(id);
            return Ok();
        }
    }
}