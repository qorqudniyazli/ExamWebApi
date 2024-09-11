using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.StudentDTOs;

public class StudentToAddDto
{
    [Required]
    [Range(1, 99999)] 
    public int StudentNumber { get; set; }

    [Required]
    [StringLength(30)]  
    public string FirstName { get; set; }

    [Required]
    [StringLength(30)]  
    public string LastName { get; set; }

    [Range(1, 99)]  
    public int Grade { get; set; }
}
