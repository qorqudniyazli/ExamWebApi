using AutoMapper;
using BusinessLogicLayer.Abstract;
using DataAcsessLayer.Abstract;
using DTO.StudentDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _rep;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository rep, IMapper mapper)
    {
        _rep = rep;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentToListDto>> GetAllStudentsAsync()
    {
        var students = await _rep.GetAllStudentsAsync();
        return _mapper.Map<IEnumerable<StudentToListDto>>(students);
    }

    public async Task<StudentToListDto> GetStudentByNumberAsync(int number)
    {
        var student = await _rep.GetStudentByNumberAsync(number);
        return _mapper.Map<StudentToListDto>(student);
    }

    public async Task AddStudentAsync(StudentToAddDto studentDto)
    {
        var student = _mapper.Map<Student>(studentDto);
        await _rep.AddStudentAsync(student);
    }

    public async Task UpdateStudentAsync(StudentToAddDto studentDto)
    {
        var student = _mapper.Map<Student>(studentDto);
        await _rep.UpdateStudentAsync(student);
    }

    public async Task DeleteStudentAsync(int number)
    {
        await _rep.DeleteStudentAsync(number);
    }
}
