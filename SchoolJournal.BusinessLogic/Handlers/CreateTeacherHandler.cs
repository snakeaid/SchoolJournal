using MassTransit;
using MediatR;
using SchoolJournal.BusinessLogic.Commands;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Handlers;

/// <summary>
/// MediatR handler class which handles the command to post a teacher and
/// implements <see cref="IRequestHandler{TRequest,TResponse}"/> for
/// <see cref="CreateTeacherCommand"/>, <see cref="TeacherViewModel"/>.
/// </summary>
public class CreateTeacherHandler : IRequestHandler<CreateTeacherCommand, TeacherViewModel>
{
    private readonly IRequestClient<TeacherCreateModel> _client;

    /// <summary>
    /// Constructs and instance of <see cref="CreateTeacherHandler"/> using the specified request client.
    /// </summary>
    /// <param name="client">An instance of <see cref="IRequestClient{TRequest}"/> for <see cref="TeacherCreateModel"/>.</param>
    public CreateTeacherHandler(IRequestClient<TeacherCreateModel> client)
    {
        _client = client;
    }

    /// <summary>
    /// Handles the specified request to post a teacher.
    /// </summary>
    /// <param name="request">Request to post a teacher.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="TeacherViewModel"/></returns>
    public async Task<TeacherViewModel> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        var response = await _client.GetResponse<TeacherViewModel>(request.Model, cancellationToken);
        return response.Message;
    }
}