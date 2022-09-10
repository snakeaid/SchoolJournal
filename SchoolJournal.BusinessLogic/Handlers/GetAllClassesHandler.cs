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
/// MediatR handler class which handles the query to get all classes and
/// implements <see cref="IRequestHandler{TRequest,TResponse}"/> for
/// <see cref="GetAllClassesQuery"/>, <see cref="List{T}"/> for <see cref="ClassViewModel"/>.
/// </summary>
public class GetAllClassesHandler : IRequestHandler<GetAllClassesQuery, List<ClassViewModel>>
{
    private readonly ApplicationContext _context;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructs an instance of <see cref="GetAllClassesHandler"/> using the specified context, mapper and logger.
    /// </summary>
    /// <param name="context">An instance of <see cref="ApplicationContext"/>.</param>
    /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
    /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/> for <see cref="GetAllClassesHandler"/>.</param>
    public GetAllClassesHandler(ApplicationContext context, IMapper mapper, ILogger<GetAllClassesHandler> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Handles the specified request to get all classes.
    /// </summary>
    /// <param name="request">Request to get all classes.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="List{T}"/> for <see cref="ClassViewModel"/></returns>
    public async Task<List<ClassViewModel>> Handle(GetAllClassesQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting all classes.");
        var list = await _context.CompleteClasses().ToListAsync(cancellationToken);
        var listModel = _mapper.Map<List<ClassViewModel>>(list);
        _logger.LogInformation("Got all classes successfully.");

        return listModel;
    }
}