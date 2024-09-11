using DTO.LessonDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract;

public interface ILessonService
{
    Task<IEnumerable<LessonToListDto>> GetAllLessonsAsync();
    Task<LessonToListDto> GetLessonByCodeAsync(string code);
    Task AddLessonAsync(LessonToAddDto lessonDto);
    Task UpdateLessonAsync(LessonToAddDto lessonDto);
    Task DeleteLessonAsync(string code);
}
