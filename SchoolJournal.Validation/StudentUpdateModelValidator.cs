using FluentValidation;
using SchoolJournal.Primitives;

namespace SchoolJournal.Validation;

/// <summary>
/// This class provides validation for <see cref="StudentUpdateModel"/> and implements
/// <see cref="AbstractValidator{T}"/> for <see cref="StudentUpdateModel"/>.
/// </summary>
public class StudentUpdateModelValidator : AbstractValidator<StudentUpdateModel>
{
    /// <summary>
    /// Constructs an instance of <see cref="StudentUpdateModelValidator"/>.
    /// </summary>
    public StudentUpdateModelValidator()
    {
        RuleFor(x => x.ClassId).GreaterThan(0);
        //RuleFor(x => LocalDate.FromDateTime(DateTime.Now).Minus(x.Birthday).Years).LessThanOrEqualTo(18);
        RuleFor(x => x.FirstName).MinimumLength(2).MaximumLength(15);
        RuleFor(x => x.LastName).MinimumLength(3).MaximumLength(15);
    }
}