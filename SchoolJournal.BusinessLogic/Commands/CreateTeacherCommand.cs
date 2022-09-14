using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Commands;

/// <summary>
/// MediatR request class which represents a command to add a new teacher and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="TeacherViewModel"/>.
/// </summary>
public class CreateTeacherCommand : IRequest<TeacherViewModel>
{
    /// <summary>
    /// Gets and sets the model of the teacher to be added.
    /// </summary>
    public TeacherCreateModel Model { get; set; } = null!;
}