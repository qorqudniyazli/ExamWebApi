using DataAcsessLayer.Abstract;
using DataAcsessLayer.Context;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Concrete;

public class LessonRepository : ILessonRepository
{
    private readonly ApplicationDbContext _context;

    public LessonRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Lesson>> GetAllLessonsAsync()
    {
        return await _context.Lessons.ToListAsync();
    }

    public async Task<Lesson> GetLessonByCodeAsync(string code)
    {
        return await _context.Lessons.FindAsync(code);
    }

    public async Task AddLessonAsync(Lesson lesson)
    {
        await _context.Lessons.AddAsync(lesson);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateLessonAsync(Lesson lesson)
    {
        _context.Lessons.Update(lesson);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLessonAsync(string code)
    {
        var lesson = await _context.Lessons.FindAsync(code);
        if (lesson != null)
        {
            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
        }
    }
}
