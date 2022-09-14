using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Queries;

/// <summary>
/// MediatR request sStudent which represents a query to get a student and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="StudentViewModel"/>.
/// </summary>
public class GetStudentQuery : IRequest<StudentViewModel>
{
    /// <summary>
    /// Gets and sets the identifier of the queried student.
    /// </summary>
    public int Id { get; set; }
}