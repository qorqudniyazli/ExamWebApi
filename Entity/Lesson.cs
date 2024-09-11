using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity;

public class Lesson
{
    [Key]
    [StringLength(3, MinimumLength = 3)]  
    public string LessonCode { get; set; }

    [Required]
    [StringLength(30)] 
    public string LessonName { get; set; }

    [Range(1, 99)]  
    public int Grade { get; set; }

    [Required]
    [StringLength(20)]  
    public string TeacherFirstName { get; set; }

    [Required]
    [StringLength(20)] 
    public string TeacherLastName { get; set; }

    public ICollection<Exam> Exams { get; set; }
}
