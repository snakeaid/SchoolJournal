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
/// MediatR handler class which handles the query to get all teachers and
/// implements <see cref="IRequestHandler{TRequest,TResponse}"/> for
/// <see cref="GetAllTeachersQuery"/>, <see cref="List{T}"/> for <see cref="TeacherViewModel"/>.
/// </summary>
public class GetAllTeachersHandler : IRequestHandler<GetAllTeachersQuery, List<TeacherViewModel>>
{
    private readonly ApplicationContext _context;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructs an instance of <see cref="GetAllTeachersHandler"/> using the specified context, mapper and logger.
    /// </summary>
    /// <param name="context">An instance of <see cref="ApplicationContext"/>.</param>
    /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
    /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/> for <see cref="GetAllTeachersHandler"/>.</param>
    public GetAllTeachersHandler(ApplicationContext context, IMapper mapper, ILogger<GetAllTeachersHandler> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Handles the specified request to get all teachers.
    /// </summary>
    /// <param name="request">Request to get all teachers.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="List{T}"/> for <see cref="TeacherViewModel"/></returns>
    public async Task<List<TeacherViewModel>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting all teachers.");
        var list = await _context.CompleteTeachers().ToListAsync(cancellationToken);
        var listModel = _mapper.Map<List<TeacherViewModel>>(list);
        _logger.LogInformation("Got all teachers successfully.");

        return listModel;
    }
}