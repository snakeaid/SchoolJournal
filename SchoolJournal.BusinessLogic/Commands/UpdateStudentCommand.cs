using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Commands;

/// <summary>
/// MediatR request class which represents a command to update a student and
/// implements <see cref="IRequest"/> for <see cref="StudentViewModel"/>.
/// </summary>
public class UpdateStudentCommand : IRequest<StudentViewModel>
{
    /// <summary>
    /// Gets and sets the model of the student to be updated.
    /// </summary>
    public StudentUpdateModel Model { get; set; } = null!;
}