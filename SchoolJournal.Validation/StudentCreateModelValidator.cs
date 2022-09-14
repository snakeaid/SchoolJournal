using FluentValidation;
using SchoolJournal.Primitives;

namespace SchoolJournal.Validation;

/// <summary>
/// This class provides validation for <see cref="StudentCreateModel"/> and implements
/// <see cref="AbstractValidator{T}"/> for <see cref="StudentCreateModel"/>.
/// </summary>
public class StudentCreateModelValidator : AbstractValidator<StudentCreateModel>
{
    /// <summary>
    /// Constructs an instance of <see cref="StudentCreateModelValidator"/>.
    /// </summary>
    public StudentCreateModelValidator()
    {
        RuleFor(x => x.ClassId).GreaterThan(0);
        //RuleFor(x => LocalDate.FromDateTime(DateTime.Now).Minus(x.Birthday).Years).LessThanOrEqualTo(18);
        RuleFor(x => x.FirstName).MinimumLength(2).MaximumLength(15);
        RuleFor(x => x.LastName).MinimumLength(3).MaximumLength(15);
    }
}