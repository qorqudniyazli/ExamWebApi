using API.ActionFilters;
using BusinessLogicLayer.Abstract;
using DTO.ExamDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExams()
        {
            var exams = await _examService.GetAllExamsAsync();
            return Ok(exams);
        }

        [HttpGet("{lessonCode}/{studentNumber}")]
        public async Task<IActionResult> GetExamByLessonAndStudent(string lessonCode, int studentNumber)
        {
            var exam = await _examService.GetExamByIdAsync(lessonCode, studentNumber);
            if (exam == null)
                return NotFound();

            return Ok(exam);
        }

        [ServiceFilter(typeof(ValidationFilter<ExamToAddDto>))]
        [HttpPost]
        public async Task<IActionResult> AddExam([FromBody] ExamToAddDto examDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _examService.AddExamAsync(examDto);
            return CreatedAtAction(nameof(GetExamByLessonAndStudent), new { lessonCode = examDto.LessonCode, studentNumber = examDto.StudentNumber }, examDto);
        }

        [HttpPut("{lessonCode}/{studentNumber}")]
        public async Task<IActionResult> UpdateExam(string lessonCode, int studentNumber, [FromBody] ExamToAddDto examDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingExam = await _examService.GetExamByIdAsync(lessonCode, studentNumber);
            if (existingExam == null)
                return NotFound();

            await _examService.UpdateExamAsync(examDto);
            return NoContent();
        }

        [HttpDelete("{lessonCode}/{studentNumber}")]
        public async Task<IActionResult> DeleteExam(string lessonCode, int studentNumber)
        {
            var existingExam = await _examService.GetExamByIdAsync(lessonCode, studentNumber);
            if (existingExam == null)
                return NotFound();

            await _examService.DeleteExamAsync(lessonCode, studentNumber);
            return NoContent();
        }
    }
}

