using DTO.ExamDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract;

public interface IExamService
{
    Task<IEnumerable<ExamToListDto>> GetAllExamsAsync();
    Task<ExamToListDto> GetExamByIdAsync(string lessonCode, int studentNumber);
    Task AddExamAsync(ExamToAddDto examDto);
    Task UpdateExamAsync(ExamToAddDto examDto);
    Task DeleteExamAsync(string lessonCode, int studentNumber);
}
