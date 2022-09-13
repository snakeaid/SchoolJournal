using MassTransit;
using MediatR;
using SchoolJournal.BusinessLogic.Commands;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Handlers;

/// <summary>
/// MediatR handler class which handles the command to post a class and
/// implements <see cref="IRequestHandler{TRequest,TResponse}"/> for
/// <see cref="CreateClassCommand"/>, <see cref="ClassViewModel"/>.
/// </summary>
public class CreateClassHandler : IRequestHandler<CreateClassCommand, ClassViewModel>
{
    private readonly IRequestClient<ClassCreateModel> _client;

    /// <summary>
    /// Constructs and instance of <see cref="CreateClassHandler"/> using the specified request client.
    /// </summary>
    /// <param name="client">An instance of <see cref="IRequestClient{TRequest}"/> for <see cref="ClassCreateModel"/>.</param>
    public CreateClassHandler(IRequestClient<ClassCreateModel> client)
    {
        _client = client;
    }

    /// <summary>
    /// Handles the specified request to post a class.
    /// </summary>
    /// <param name="request">Request to get a class.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="ClassViewModel"/></returns>
    public async Task<ClassViewModel> Handle(CreateClassCommand request, CancellationToken cancellationToken)
    {
        var response = await _client.GetResponse<ClassViewModel>(request.Model, cancellationToken);
        return response.Message;
    }
}