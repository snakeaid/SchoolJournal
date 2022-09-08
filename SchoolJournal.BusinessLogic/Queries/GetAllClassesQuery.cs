using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Queries;

/// <summary>
/// MediatR request class which represents a query to get a class and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="List{T}"/> for <see cref="ClassViewModel"/>.
/// </summary>
public class GetAllClassesQuery : IRequest<List<ClassViewModel>>
{
}