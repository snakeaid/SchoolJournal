using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Commands;

/// <summary>
/// MediatR request class which represents a command to update a teacher and
/// implements <see cref="IRequest"/> for <see cref="TeacherViewModel"/>.
/// </summary>
public class UpdateTeacherCommand : IRequest<TeacherViewModel>
{
    /// <summary>
    /// Gets and sets the model of the teacher to be updated.
    /// </summary>
    public TeacherUpdateModel Model { get; set; } = null!;
}