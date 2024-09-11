using API.ActionFilters;
using BusinessLogicLayer.Abstract;
using DTO.LessonDTOs;
using DTO.StudentDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _service.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{number}")]
        public async Task<IActionResult> GetStudentByNumber(int number)
        {
            var student = await _service.GetStudentByNumberAsync(number);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [ServiceFilter(typeof(ValidationFilter<StudentToAddDto>))]
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentToAddDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddStudentAsync(studentDto);
            return CreatedAtAction(nameof(GetStudentByNumber), new { number = studentDto.StudentNumber }, studentDto);
        }

        [HttpPut("{number}")]
        public async Task<IActionResult> UpdateStudent(int number, [FromBody] StudentToAddDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingStudent = await _service.GetStudentByNumberAsync(number);
            if (existingStudent == null)
                return NotFound();

            await _service.UpdateStudentAsync( studentDto);
            return NoContent();
        }

        [HttpDelete("{number}")]
        public async Task<IActionResult> DeleteStudent(int number)
        {
            var existingStudent = await _service.GetStudentByNumberAsync(number);
            if (existingStudent == null)
                return NotFound();

            await _service.DeleteStudentAsync(number);
            return NoContent();
        }
    }
}

