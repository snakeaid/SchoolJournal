using MassTransit;
using MediatR;
using SchoolJournal.BusinessLogic.Commands;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Handlers;

/// <summary>
/// MediatR handler class which handles the command to delete a teacher and
/// implements <see cref="IRequestHandler{TRequest}"/> for
/// <see cref="DeleteTeacherCommand"/>, <see cref="TeacherViewModel"/>.
/// </summary>
public class DeleteTeacherHandler : IRequestHandler<DeleteTeacherCommand, TeacherViewModel>
{
    private readonly IRequestClient<TeacherDeleteModel> _client;

    /// <summary>
    /// Constructs and instance of <see cref="DeleteTeacherHandler"/> using the specified request client.
    /// </summary>
    /// <param name="client">An instance of <see cref="IRequestClient{TRequest}"/> for <see cref="TeacherDeleteModel"/>.</param>
    public DeleteTeacherHandler(IRequestClient<TeacherDeleteModel> client)
    {
        _client = client;
    }

    /// <summary>
    /// Handles the specified request to delete a teacher.
    /// </summary>
    /// <param name="request">Request to delete a teacher.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="TeacherViewModel"/></returns>
    public async Task<TeacherViewModel> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
    {
        var response = await _client.GetResponse<TeacherViewModel>(request.Model, cancellationToken);
        return response.Message;
    }
}