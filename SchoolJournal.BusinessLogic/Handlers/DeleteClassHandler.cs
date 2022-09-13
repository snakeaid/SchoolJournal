using MassTransit;
using MediatR;
using SchoolJournal.BusinessLogic.Commands;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Handlers;

/// <summary>
/// MediatR handler class which handles the command to delete a class and
/// implements <see cref="IRequestHandler{TRequest}"/> for
/// <see cref="DeleteClassCommand"/>, <see cref="ClassViewModel"/>.
/// </summary>
public class DeleteClassHandler : IRequestHandler<DeleteClassCommand, ClassViewModel>
{
    private readonly IRequestClient<ClassDeleteModel> _client;

    /// <summary>
    /// Constructs and instance of <see cref="DeleteClassHandler"/> using the specified request client.
    /// </summary>
    /// <param name="client">An instance of <see cref="IRequestClient{TRequest}"/> for <see cref="ClassDeleteModel"/>.</param>
    public DeleteClassHandler(IRequestClient<ClassDeleteModel> client)
    {
        _client = client;
    }

    /// <summary>
    /// Handles the specified request to delete a class.
    /// </summary>
    /// <param name="request">Request to delete a class.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="ClassViewModel"/></returns>
    public async Task<ClassViewModel> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
    {
        var response = await _client.GetResponse<ClassViewModel>(request.Model, cancellationToken);
        return response.Message;
    }
}