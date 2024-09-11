using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity;

public class Exam
{
    [Key, Column(Order = 0)]
    [StringLength(3, MinimumLength = 3)]  
    public string LessonCode { get; set; }

    [Key, Column(Order = 1)]
    [Range(1, 99999)]  
    public int StudentNumber { get; set; }

    [Required]
    public DateTime ExamDate { get; set; } 

    [Range(0, 9)]  
    public int Score { get; set; }

    [ForeignKey("LessonCode")]
    public Lesson Lesson { get; set; }   

    [ForeignKey("StudentNumber")]
    public Student Student { get; set; } 
}
