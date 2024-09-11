using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Abstract;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllStudentsAsync();
    Task<Student> GetStudentByNumberAsync(int number);
    Task AddStudentAsync(Student student);
    Task UpdateStudentAsync(Student student);
    Task DeleteStudentAsync(int number);
}
