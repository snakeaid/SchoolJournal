using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Queries;

/// <summary>
/// MediatR request sSubject which represents a query to get a subject and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="SubjectViewModel"/>.
/// </summary>
public class GetSubjectQuery : IRequest<SubjectViewModel>
{
    /// <summary>
    /// Gets and sets the identifier of the queried subject.
    /// </summary>
    public int Id { get; set; }
}