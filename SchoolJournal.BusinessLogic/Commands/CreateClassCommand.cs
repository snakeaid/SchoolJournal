using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Commands;

/// <summary>
/// MediatR request class which represents a command to add a new class and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="ClassViewModel"/>.
/// </summary>
public class CreateClassCommand : IRequest<ClassViewModel>
{
    /// <summary>
    /// Gets and sets the model of the class to be added.
    /// </summary>
    public ClassCreateModel Model { get; set; } = null!;
}