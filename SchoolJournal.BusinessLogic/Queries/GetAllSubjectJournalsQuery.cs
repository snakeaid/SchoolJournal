using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Queries;

/// <summary>
/// MediatR request class which represents a query to get all subject journals and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="List{T}"/> for <see cref="SubjectJournalViewModel"/>.
/// </summary>
public class GetAllSubjectJournalsQuery : IRequest<List<SubjectJournalViewModel>>
{
}