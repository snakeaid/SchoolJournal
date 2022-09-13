using MassTransit;
using MediatR;
using SchoolJournal.BusinessLogic.Commands;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Handlers;

/// <summary>
/// MediatR handler class which handles the command to update a class and
/// implements <see cref="IRequestHandler{TRequest,TResponse}"/> for
/// <see cref="UpdateClassCommand"/>, <see cref="ClassViewModel"/>.
/// </summary>
public class UpdateClassHandler : IRequestHandler<UpdateClassCommand, ClassViewModel>
{
    private readonly IRequestClient<ClassUpdateModel> _client;

    /// <summary>
    /// Constructs and instance of <see cref="UpdateClassHandler"/> using the specified request client.
    /// </summary>
    /// <param name="client">An instance of <see cref="IRequestClient{TRequest}"/> for <see cref="ClassUpdateModel"/>.</param>
    public UpdateClassHandler(IRequestClient<ClassUpdateModel> client)
    {
        _client = client;
    }

    /// <summary>
    /// Handles the specified request to post a class.
    /// </summary>
    /// <param name="request">Request to get a class.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="ClassViewModel"/></returns>
    public async Task<ClassViewModel> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
    {
        var response = await _client.GetResponse<ClassViewModel>(request.Model, cancellationToken);
        return response.Message;
    }
}