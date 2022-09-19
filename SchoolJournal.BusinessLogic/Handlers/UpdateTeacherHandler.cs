using MassTransit;
using MediatR;
using SchoolJournal.BusinessLogic.Commands;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Handlers;

/// <summary>
/// MediatR handler class which handles the command to update a teacher and
/// implements <see cref="IRequestHandler{TRequest,TResponse}"/> for
/// <see cref="UpdateTeacherCommand"/>, <see cref="TeacherViewModel"/>.
/// </summary>
public class UpdateTeacherHandler : IRequestHandler<UpdateTeacherCommand, TeacherViewModel>
{
    private readonly IRequestClient<TeacherUpdateModel> _client;

    /// <summary>
    /// Constructs and instance of <see cref="UpdateTeacherHandler"/> using the specified request client.
    /// </summary>
    /// <param name="client">An instance of <see cref="IRequestClient{TRequest}"/> for <see cref="TeacherUpdateModel"/>.</param>
    public UpdateTeacherHandler(IRequestClient<TeacherUpdateModel> client)
    {
        _client = client;
    }

    /// <summary>
    /// Handles the specified request to post a teacher.
    /// </summary>
    /// <param name="request">Request to get a teacher.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="TeacherViewModel"/></returns>
    public async Task<TeacherViewModel> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
    {
        var response = await _client.GetResponse<TeacherViewModel>(request.Model, cancellationToken);
        return response.Message;
    }
}