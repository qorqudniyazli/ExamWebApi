using DTO.ExamDTOs;
using DTO.LessonDTOs;
using DTO.StudentDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.GenericValidator;

public class GenericValidator<T> : AbstractValidator<T>
{
    public GenericValidator()
    {
        if (typeof(T) == typeof(LessonToAddDto))
        {
            RuleFor(x => ((LessonToAddDto)(object)x).LessonCode)
            .NotEmpty().WithMessage("Kod tələb olunur.")
            .Length(3).WithMessage("Kod tam olaraq 3 simvoldan ibarət olmalıdır.");

            RuleFor(x => ((LessonToAddDto)(object)x).LessonName)
                    .NotEmpty().WithMessage("Ad tələb olunur.")
                    .Length(1, 30).WithMessage("Ad 1 ilə 30 simvol arasında olmalıdır.");

            RuleFor(x => ((LessonToAddDto)(object)x).Grade)
                    .InclusiveBetween(1, 99).WithMessage("Sinif 1 ilə 99 arasında olmalıdır.");

            RuleFor(x => ((LessonToAddDto)(object)x).TeacherFirstName)
                    .NotEmpty().WithMessage("Müəllimin adı tələb olunur.")
                    .Length(1, 20).WithMessage("Müəllimin adı 1 ilə 20 simvol arasında olmalıdır.");

            RuleFor(x => ((LessonToAddDto)(object)x).TeacherLastName)
                    .NotEmpty().WithMessage("Müəllimin soyadı tələb olunur.")
                    .Length(1, 20).WithMessage("Müəllimin soyadı 1 ilə 20 simvol arasında olmalıdır.");
        }


        if (typeof(T) == typeof(ExamToAddDto))
        {
            RuleFor(x => ((ExamToAddDto)(object)x).LessonCode)
            .NotEmpty().WithMessage("Dərs kodu tələb olunur.")
            .Length(3).WithMessage("Dərs kodu tam olaraq 3 simvoldan ibarət olmalıdır.");

            RuleFor(x => ((ExamToAddDto)(object)x).StudentNumber)
                .GreaterThan(0).WithMessage("Tələbə nömrəsi 0-dan böyük olmalıdır.")
                .LessThan(100000).WithMessage("Tələbə nömrəsi 100000-dən kiçik olmalıdır.");

            RuleFor(x => ((ExamToAddDto)(object)x).ExamDate)
                .NotEmpty().WithMessage("İmtahan tarixi tələb olunur.");

            RuleFor(x => ((ExamToAddDto)(object)x).Score)
                .InclusiveBetween(0, 10).WithMessage("Qiymət 0 ilə 10 arasında olmalıdır.");
        }

        if (typeof(T) == typeof(StudentToAddDto))
        {
            RuleFor(x => ((StudentToAddDto)(object)x).StudentNumber)
            .GreaterThan(0).WithMessage("Nömrə 0-dan böyük olmalıdır.")
            .LessThan(100000).WithMessage("Nömrə 100000-dən kiçik olmalıdır.");

            RuleFor(x => ((StudentToAddDto)(object)x).FirstName)
                .NotEmpty().WithMessage("Ad tələb olunur.")
                .Length(1, 30).WithMessage("Ad 1 ilə 30 simvol arasında olmalıdır.");

            RuleFor(x => ((StudentToAddDto)(object)x).LastName)
                .NotEmpty().WithMessage("Soyad tələb olunur.")
                .Length(1, 30).WithMessage("Soyad 1 ilə 30 simvol arasında olmalıdır.");

            RuleFor(x => ((StudentToAddDto)(object)x).Grade)
                .InclusiveBetween(1, 99).WithMessage("Sinif 1 ilə 99 arasında olmalıdır.");
        }

    }
}
