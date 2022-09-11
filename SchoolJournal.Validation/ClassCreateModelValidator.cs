using FluentValidation;
using SchoolJournal.Primitives;

namespace SchoolJournal.Validation;

/// <summary>
/// This class provides validation for <see cref="ClassCreateModel"/> and implements
/// <see cref="AbstractValidator{T}"/> for <see cref="ClassCreateModel"/>.
/// </summary>
public class ClassCreateModelValidator : AbstractValidator<ClassCreateModel>
{
    /// <summary>
    /// Constructs an instance of <see cref="ClassCreateModelValidator"/>.
    /// </summary>
    public ClassCreateModelValidator()
    {
        RuleFor(x => x.Number).InclusiveBetween(1, 11);
        RuleFor(x => x.ClassTeacherId).GreaterThan(0);
    }
}