using DTO.StudentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract;

public interface IStudentService
{
    Task<IEnumerable<StudentToListDto>> GetAllStudentsAsync();
    Task<StudentToListDto> GetStudentByNumberAsync(int number);
    Task AddStudentAsync(StudentToAddDto studentDto);
    Task UpdateStudentAsync(StudentToAddDto studentDto);
    Task DeleteStudentAsync(int number);
}
