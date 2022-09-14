using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Queries;

/// <summary>
/// MediatR request class which represents a query to get all teachers and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="List{T}"/> for <see cref="TeacherViewModel"/>.
/// </summary>
public class GetAllTeachersQuery : IRequest<List<TeacherViewModel>>
{
}