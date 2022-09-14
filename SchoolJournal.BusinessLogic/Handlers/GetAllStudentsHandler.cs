using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolJournal.BusinessLogic.Extensions;
using SchoolJournal.BusinessLogic.Queries;
using SchoolJournal.DataAccess;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Handlers;

/// <summary>
/// MediatR handler class which handles the query to get all students and
/// implements <see cref="IRequestHandler{TRequest,TResponse}"/> for
/// <see cref="GetAllStudentsQuery"/>, <see cref="List{T}"/> for <see cref="StudentViewModel"/>.
/// </summary>
public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, List<StudentViewModel>>
{
    private readonly ApplicationContext _context;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructs an instance of <see cref="GetAllStudentsHandler"/> using the specified context, mapper and logger.
    /// </summary>
    /// <param name="context">An instance of <see cref="ApplicationContext"/>.</param>
    /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
    /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/> for <see cref="GetAllStudentsHandler"/>.</param>
    public GetAllStudentsHandler(ApplicationContext context, IMapper mapper, ILogger<GetAllStudentsHandler> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Handles the specified request to get all students.
    /// </summary>
    /// <param name="request">Request to get all students.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="List{T}"/> for <see cref="StudentViewModel"/></returns>
    public async Task<List<StudentViewModel>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting all students.");
        var list = await _context.CompleteStudents().ToListAsync(cancellationToken);
        var listModel = _mapper.Map<List<StudentViewModel>>(list);
        _logger.LogInformation("Got all students successfully.");

        return listModel;
    }
}