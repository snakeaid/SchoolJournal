using MassTransit;
using MediatR;
using SchoolJournal.BusinessLogic.Commands;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Handlers;

/// <summary>
/// MediatR handler class which handles the command to post a student and
/// implements <see cref="IRequestHandler{TRequest,TResponse}"/> for
/// <see cref="CreateStudentCommand"/>, <see cref="StudentViewModel"/>.
/// </summary>
public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentViewModel>
{
    private readonly IRequestClient<StudentCreateModel> _client;

    /// <summary>
    /// Constructs and instance of <see cref="CreateStudentHandler"/> using the specified request client.
    /// </summary>
    /// <param name="client">An instance of <see cref="IRequestClient{TRequest}"/> for <see cref="StudentCreateModel"/>.</param>
    public CreateStudentHandler(IRequestClient<StudentCreateModel> client)
    {
        _client = client;
    }

    /// <summary>
    /// Handles the specified request to post a student.
    /// </summary>
    /// <param name="request">Request to post a student.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="StudentViewModel"/></returns>
    public async Task<StudentViewModel> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var response = await _client.GetResponse<StudentViewModel>(request.Model, cancellationToken);
        return response.Message;
    }
}