using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LessonDTOs;

public class LessonToListDto
{
    public string LessonCode { get; set; } 
    public string LessonName { get; set; }
    public int Grade { get; set; }          
    public string TeacherFirstName { get; set; } 
    public string TeacherLastName { get; set; }
}
