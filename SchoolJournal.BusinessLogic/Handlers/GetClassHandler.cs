using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolJournal.BusinessLogic.Queries;
using SchoolJournal.DataAccess;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Handlers;

/// <summary>
/// MediatR handler class which handles the query to get a class and
/// implements <see cref="IRequestHandler{TRequest,TResponse}"/> for
/// <see cref="GetAllClassesQuery"/>, <see cref="ClassViewModel"/>.
/// </summary>
public class GetClassHandler : IRequestHandler<GetClassQuery, ClassViewModel>
{
    private readonly ApplicationContext _context;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructs an instance of <see cref="GetClassHandler"/> using the specified context and mapper.
    /// </summary>
    /// <param name="context">An instance of <see cref="ApplicationContext"/>.</param>
    /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
    /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/> for <see cref="GetClassHandler"/>.</param>
    public GetClassHandler(ApplicationContext context, IMapper mapper, ILogger<GetClassHandler> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Handles the specified request to get a class.
    /// </summary>
    /// <param name="request">Request to get a class.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="ClassViewModel"/></returns>
    /// <exception cref="KeyNotFoundException">Thrown if no class with the specified ID is found.</exception>
    public async Task<ClassViewModel> Handle(GetClassQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Getting class : ID {request.Id}.");
        var entity = await _context.Classes.Include(x => x.Students).Include(x => x.ClassTeacher)
            .Include(x => x.Journal)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"Class NOT FOUND : ID {request.Id}.");
        var model = _mapper.Map<ClassViewModel>(entity);
        _logger.LogInformation($"Got class successfully : ID {request.Id}.");

        return model;
    }
}