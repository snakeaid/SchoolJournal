using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Queries;

/// <summary>
/// MediatR request class which represents a query to get a class and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="ClassViewModel"/>.
/// </summary>
public class GetClassQuery : IRequest<ClassViewModel>
{
    /// <summary>
    /// Gets and sets the identifier of the queried class.
    /// </summary>
    public int Id { get; set; }
}