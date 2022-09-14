using MassTransit;
using MediatR;
using SchoolJournal.BusinessLogic.Commands;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Handlers;

/// <summary>
/// MediatR handler class which handles the command to delete a student and
/// implements <see cref="IRequestHandler{TRequest}"/> for
/// <see cref="DeleteStudentCommand"/>, <see cref="StudentViewModel"/>.
/// </summary>
public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, StudentViewModel>
{
    private readonly IRequestClient<StudentDeleteModel> _client;

    /// <summary>
    /// Constructs and instance of <see cref="DeleteStudentHandler"/> using the specified request client.
    /// </summary>
    /// <param name="client">An instance of <see cref="IRequestClient{TRequest}"/> for <see cref="StudentDeleteModel"/>.</param>
    public DeleteStudentHandler(IRequestClient<StudentDeleteModel> client)
    {
        _client = client;
    }

    /// <summary>
    /// Handles the specified request to delete a student.
    /// </summary>
    /// <param name="request">Request to delete a student.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="StudentViewModel"/></returns>
    public async Task<StudentViewModel> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var response = await _client.GetResponse<StudentViewModel>(request.Model, cancellationToken);
        return response.Message;
    }
}