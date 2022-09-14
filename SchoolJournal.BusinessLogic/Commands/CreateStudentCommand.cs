using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Commands;

/// <summary>
/// MediatR request class which represents a command to add a new student and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="StudentViewModel"/>.
/// </summary>
public class CreateStudentCommand : IRequest<StudentViewModel>
{
    /// <summary>
    /// Gets and sets the model of the student to be added.
    /// </summary>
    public StudentCreateModel Model { get; set; } = null!;
}