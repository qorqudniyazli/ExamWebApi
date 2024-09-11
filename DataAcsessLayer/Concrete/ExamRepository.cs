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

public class ExamRepository : IExamRepository
{
    private readonly ApplicationDbContext _context;

    public ExamRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Exam>> GetAllExamsAsync()
    {
        return await _context.Exams.ToListAsync();
    }

    public async Task<Exam> GetExamByIdAsync(string lessonCode, int studentNumber)
    {
        return await _context.Exams.FindAsync(lessonCode, studentNumber);
    }

    public async Task AddExamAsync(Exam exam)
    {
        await _context.Exams.AddAsync(exam);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateExamAsync(Exam exam)
    {
        _context.Exams.Update(exam);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteExamAsync(string lessonCode, int studentNumber)
    {
        var exam = await _context.Exams.FindAsync(lessonCode, studentNumber);
        if (exam != null)
        {
            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
        }
    }
}
