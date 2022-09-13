using FluentValidation;
using SchoolJournal.Primitives;

namespace SchoolJournal.Validation;

/// <summary>
/// This class provides validation for <see cref="ClassUpdateModel"/> and implements
/// <see cref="AbstractValidator{T}"/> for <see cref="ClassUpdateModel"/>.
/// </summary>
public class ClassUpdateModelValidator : AbstractValidator<ClassUpdateModel>
{
    /// <summary>
    /// Constructs an instance of <see cref="ClassUpdateModelValidator"/>.
    /// </summary>
    public ClassUpdateModelValidator()
    {
        RuleFor(x => x.Number).InclusiveBetween(1, 11);
        RuleFor(x => x.ClassTeacherId).GreaterThan(0);
    }
}