using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Commands;

/// <summary>
/// MediatR request class which represents a command to delete a teacher and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="TeacherViewModel"/>.
/// </summary>
public class DeleteTeacherCommand : IRequest<TeacherViewModel>
{
    /// <summary>
    /// Gets and sets the model of the teacher to be deleted.
    /// </summary>
    public TeacherDeleteModel Model { get; set; } = null!;
}