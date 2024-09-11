using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ExamDTOs;

public class ExamToListDto
{
    public string LessonCode { get; set; } 
    public int StudentNumber { get; set; } 
    public DateTime ExamDate { get; set; } 
    public int Score { get; set; }
}
