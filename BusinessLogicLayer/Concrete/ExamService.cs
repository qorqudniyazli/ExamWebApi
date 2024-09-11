using AutoMapper;
using BusinessLogicLayer.Abstract;
using DataAcsessLayer.Abstract;
using DTO.ExamDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete;

public class ExamService : IExamService
{
    private readonly IExamRepository _rep;
    private readonly IMapper _mapper;

    public ExamService(IExamRepository rep, IMapper mapper)
    {
        _rep = rep;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ExamToListDto>> GetAllExamsAsync()
    {
        var exams = await _rep.GetAllExamsAsync();
        return _mapper.Map<IEnumerable<ExamToListDto>>(exams);
    }

    public async Task<ExamToListDto> GetExamByIdAsync(string lessonCode, int studentNumber)
    {
        var exam = await _rep.GetExamByIdAsync(lessonCode, studentNumber);
        return _mapper.Map<ExamToListDto>(exam);
    }

    public async Task AddExamAsync(ExamToAddDto examDto)
    {
        var exam = _mapper.Map<Exam>(examDto);
        await _rep.AddExamAsync(exam);
    }

    public async Task UpdateExamAsync(ExamToAddDto examDto)
    {
        var exam = _mapper.Map<Exam>(examDto);
        await _rep.UpdateExamAsync(exam);
    }

    public async Task DeleteExamAsync(string lessonCode, int studentNumber)
    {
        await _rep.DeleteExamAsync(lessonCode, studentNumber);
    }

}
