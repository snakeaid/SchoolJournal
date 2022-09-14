using MassTransit;
using MediatR;
using SchoolJournal.BusinessLogic.Commands;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Handlers;

/// <summary>
/// MediatR handler class which handles the command to update a student and
/// implements <see cref="IRequestHandler{TRequest,TResponse}"/> for
/// <see cref="UpdateStudentCommand"/>, <see cref="StudentViewModel"/>.
/// </summary>
public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, StudentViewModel>
{
    private readonly IRequestClient<StudentUpdateModel> _client;

    /// <summary>
    /// Constructs and instance of <see cref="UpdateStudentHandler"/> using the specified request client.
    /// </summary>
    /// <param name="client">An instance of <see cref="IRequestClient{TRequest}"/> for <see cref="StudentUpdateModel"/>.</param>
    public UpdateStudentHandler(IRequestClient<StudentUpdateModel> client)
    {
        _client = client;
    }

    /// <summary>
    /// Handles the specified request to post a student.
    /// </summary>
    /// <param name="request">Request to get a student.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="StudentViewModel"/></returns>
    public async Task<StudentViewModel> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var response = await _client.GetResponse<StudentViewModel>(request.Model, cancellationToken);
        return response.Message;
    }
}