using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Queries;

/// <summary>
/// MediatR request class which represents a query to get all classes and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="ClassModel"/>.
/// </summary>
public class GetAllClassesQuery : IRequest<List<ClassModel>>
{
}