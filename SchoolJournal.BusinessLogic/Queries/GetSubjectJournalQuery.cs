using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Queries;

/// <summary>
/// MediatR request sSubjectJournal which represents a query to get a subject journal and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="SubjectJournalViewModel"/>.
/// </summary>
public class GetSubjectJournalQuery : IRequest<SubjectJournalViewModel>
{
    /// <summary>
    /// Gets and sets the identifier of the queried subject journal.
    /// </summary>
    public Guid Id { get; set; }
}