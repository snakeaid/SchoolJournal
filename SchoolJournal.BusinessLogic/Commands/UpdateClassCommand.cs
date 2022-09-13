using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Commands;

/// <summary>
/// MediatR request class which represents a command to update a class and
/// implements <see cref="IRequest"/> for <see cref="ClassViewModel"/>.
/// </summary>
public class UpdateClassCommand : IRequest<ClassViewModel>
{
    /// <summary>
    /// Gets and sets the model of the class to be updated.
    /// </summary>
    public ClassUpdateModel Model { get; set; } = null!;
}