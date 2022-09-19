using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Queries;

/// <summary>
/// MediatR request class which represents a query to get all subjects and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="List{T}"/> for <see cref="SubjectViewModel"/>.
/// </summary>
public class GetAllSubjectsQuery : IRequest<List<SubjectViewModel>>
{
}