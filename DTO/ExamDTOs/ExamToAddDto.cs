using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ExamDTOs;

public class ExamToAddDto
{
    [Required]
    [StringLength(3, MinimumLength = 3)] 
    public string LessonCode { get; set; }

    [Required]
    [Range(1, 99999)]  
    public int StudentNumber { get; set; }

    [Required]
    public DateTime ExamDate { get; set; } 

    [Range(0, 9)]
    public int Score { get; set; }

}
