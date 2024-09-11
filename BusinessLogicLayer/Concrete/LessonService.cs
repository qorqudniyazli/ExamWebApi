using AutoMapper;
using BusinessLogicLayer.Abstract;
using DataAcsessLayer.Abstract;
using DTO.LessonDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete;

public class LessonService : ILessonService
{
    private readonly ILessonRepository _rep;
    private readonly IMapper _mapper;

  
    public LessonService(ILessonRepository rep, IMapper mapper)
    {
        _rep = rep;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LessonToListDto>> GetAllLessonsAsync()
    {
        var lessons = await _rep.GetAllLessonsAsync();
        return _mapper.Map<IEnumerable<LessonToListDto>>(lessons);
    }

    public async Task<LessonToListDto> GetLessonByCodeAsync(string code)
    {
        var lesson = await _rep.GetLessonByCodeAsync(code);
        return _mapper.Map<LessonToListDto>(lesson);
    }

    public async Task AddLessonAsync(LessonToAddDto lessonDto)
    {
        var lesson = _mapper.Map<Lesson>(lessonDto);
        await _rep.AddLessonAsync(lesson);
    }

    public async Task UpdateLessonAsync(LessonToAddDto lessonDto)
    {
        var lesson = _mapper.Map<Lesson>(lessonDto);
        await _rep.UpdateLessonAsync(lesson);
    }

    public async Task DeleteLessonAsync(string code)
    {
        await _rep.DeleteLessonAsync(code);
    }
}
