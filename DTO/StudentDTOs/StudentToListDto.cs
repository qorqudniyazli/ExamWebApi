using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.StudentDTOs;

public class StudentToListDto
{
    public int StudentNumber { get; set; } 
    public string FirstName { get; set; }  
    public string LastName { get; set; }   
    public int Grade { get; set; }         
}
