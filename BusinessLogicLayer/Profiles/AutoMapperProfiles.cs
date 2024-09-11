using AutoMapper;
using DTO.ExamDTOs;
using DTO.LessonDTOs;
using DTO.StudentDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Profiles;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        // Lesson mappings
        CreateMap<Lesson, LessonToListDto>();
        CreateMap<LessonToAddDto, Lesson>();

        // Student mappings
        CreateMap<Student, StudentToListDto>();
        CreateMap<StudentToAddDto, Student>();

        // Exam mappings
        CreateMap<Exam, ExamToListDto>();
        CreateMap<ExamToAddDto, Exam>();
    }
}
