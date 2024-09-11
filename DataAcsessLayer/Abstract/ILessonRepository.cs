using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Abstract;

public interface ILessonRepository
{
    Task<IEnumerable<Lesson>> GetAllLessonsAsync();
    Task<Lesson> GetLessonByCodeAsync(string code);
    Task AddLessonAsync(Lesson lesson);
    Task UpdateLessonAsync(Lesson lesson);
    Task DeleteLessonAsync(string code);
}
