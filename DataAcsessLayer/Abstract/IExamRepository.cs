using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Abstract;

public interface IExamRepository
{
    Task<IEnumerable<Exam>> GetAllExamsAsync();
    Task<Exam> GetExamByIdAsync(string lessonCode, int studentNumber);
    Task AddExamAsync(Exam exam);
    Task UpdateExamAsync(Exam exam);
    Task DeleteExamAsync(string lessonCode, int studentNumber);
}
