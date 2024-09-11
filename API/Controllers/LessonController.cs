using API.ActionFilters;
using BusinessLogicLayer.Abstract;
using DTO.ExamDTOs;
using DTO.LessonDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _service;

        public LessonController(ILessonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLessons()
        {
            var lessons = await _service.GetAllLessonsAsync();
            return Ok(lessons);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetLessonByCode(string code)
        {
            var lesson = await _service.GetLessonByCodeAsync(code);
            if (lesson == null)
                return NotFound();

            return Ok(lesson);
        }

        [ServiceFilter(typeof(ValidationFilter<LessonToAddDto>))]
        [HttpPost]
        public async Task<IActionResult> AddLesson([FromBody] LessonToAddDto lessonDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddLessonAsync(lessonDto);
            return CreatedAtAction(nameof(GetLessonByCode), new { code = lessonDto.LessonCode }, lessonDto);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateLesson(string code, [FromBody] LessonToAddDto lessonDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingLesson = await _service.GetLessonByCodeAsync(code);
            if (existingLesson == null)
                return NotFound();

            await _service.UpdateLessonAsync(lessonDto);
            return NoContent();
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteLesson(string code)
        {
            var existingLesson = await _service.GetLessonByCodeAsync(code);
            if (existingLesson == null)
                return NotFound();

            await _service.DeleteLessonAsync(code);
            return NoContent();
        }
    }
}

