using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Queries;

/// <summary>
/// MediatR request sTeacher which represents a query to get a teacher and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="TeacherViewModel"/>.
/// </summary>
public class GetTeacherQuery : IRequest<TeacherViewModel>
{
    /// <summary>
    /// Gets and sets the identifier of the queried teacher.
    /// </summary>
    public int Id { get; set; }
}