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
/// MediatR handler class which handles the query to get a teacher and
/// implements <see cref="IRequestHandler{TRequest,TResponse}"/> for
/// <see cref="GetAllTeachersQuery"/>, <see cref="TeacherViewModel"/>.
/// </summary>
public class GetTeacherHandler : IRequestHandler<GetTeacherQuery, TeacherViewModel>
{
    private readonly ApplicationContext _context;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructs an instance of <see cref="GetTeacherHandler"/> using the specified context and mapper.
    /// </summary>
    /// <param name="context">An instance of <see cref="ApplicationContext"/>.</param>
    /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
    /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/> for <see cref="GetTeacherHandler"/>.</param>
    public GetTeacherHandler(ApplicationContext context, IMapper mapper, ILogger<GetTeacherHandler> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Handles the specified request to get a teacher.
    /// </summary>
    /// <param name="request">Request to get a teacher.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="TeacherViewModel"/></returns>
    /// <exception cref="KeyNotFoundException">Thrown if no teacher with the specified ID is found.</exception>
    public async Task<TeacherViewModel> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Getting teacher : ID {request.Id}.");
        var entity = await _context.CompleteTeachers().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"Teacher NOT FOUND : ID {request.Id}.");
        var model = _mapper.Map<TeacherViewModel>(entity);
        _logger.LogInformation($"Got teacher successfully : ID {request.Id}.");

        return model;
    }
}