using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Queries;

/// <summary>
/// MediatR request class which represents a query to get all students and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="List{T}"/> for <see cref="StudentViewModel"/>.
/// </summary>
public class GetAllStudentsQuery : IRequest<List<StudentViewModel>>
{
}