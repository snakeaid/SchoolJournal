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
/// MediatR handler class which handles the query to get a student and
/// implements <see cref="IRequestHandler{TRequest,TResponse}"/> for
/// <see cref="GetAllStudentsQuery"/>, <see cref="StudentViewModel"/>.
/// </summary>
public class GetStudentHandler : IRequestHandler<GetStudentQuery, StudentViewModel>
{
    private readonly ApplicationContext _context;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructs an instance of <see cref="GetStudentHandler"/> using the specified context and mapper.
    /// </summary>
    /// <param name="context">An instance of <see cref="ApplicationContext"/>.</param>
    /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
    /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/> for <see cref="GetStudentHandler"/>.</param>
    public GetStudentHandler(ApplicationContext context, IMapper mapper, ILogger<GetStudentHandler> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Handles the specified request to get a student.
    /// </summary>
    /// <param name="request">Request to get a student.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="StudentViewModel"/></returns>
    /// <exception cref="KeyNotFoundException">Thrown if no student with the specified ID is found.</exception>
    public async Task<StudentViewModel> Handle(GetStudentQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Getting student : ID {request.Id}.");
        var entity = await _context.CompleteStudents().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"Student NOT FOUND : ID {request.Id}.");
        var model = _mapper.Map<StudentViewModel>(entity);
        _logger.LogInformation($"Got student successfully : ID {request.Id}.");

        return model;
    }
}