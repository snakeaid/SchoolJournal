using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Commands;

/// <summary>
/// MediatR request class which represents a command to delete a class and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="ClassViewModel"/>.
/// </summary>
public class DeleteClassCommand : IRequest<ClassViewModel>
{
    /// <summary>
    /// Gets and sets the model of the class to be deleted.
    /// </summary>
    public ClassDeleteModel Model { get; set; } = null!;
}