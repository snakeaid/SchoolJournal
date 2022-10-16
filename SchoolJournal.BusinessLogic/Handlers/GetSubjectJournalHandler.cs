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
/// MediatR handler class which handles the query to get a subject journal and
/// implements <see cref="IRequestHandler{TRequest,TResponse}"/> for
/// <see cref="GetAllSubjectJournalsQuery"/>, <see cref="SubjectJournalViewModel"/>.
/// </summary>
public class GetSubjectJournalHandler : IRequestHandler<GetSubjectJournalQuery, SubjectJournalViewModel>
{
    private readonly ApplicationContext _context;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructs an instance of <see cref="GetSubjectJournalHandler"/> using the specified context and mapper.
    /// </summary>
    /// <param name="context">An instance of <see cref="ApplicationContext"/>.</param>
    /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
    /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/> for <see cref="GetSubjectJournalHandler"/>.</param>
    public GetSubjectJournalHandler(ApplicationContext context, IMapper mapper,
        ILogger<GetSubjectJournalHandler> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Handles the specified request to get a subject journal.
    /// </summary>
    /// <param name="request">Request to get a subject journal.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="SubjectJournalViewModel"/></returns>
    /// <exception cref="KeyNotFoundException">Thrown if no subject journal with the specified ID is found.</exception>
    public async Task<SubjectJournalViewModel> Handle(GetSubjectJournalQuery request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Getting subject journal : ID {request.Id}.");
        var entity = await _context.CompleteSubjectJournals()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SubjectJournal NOT FOUND : ID {request.Id}.");
        var model = _mapper.Map<SubjectJournalViewModel>(entity);
        _logger.LogInformation($"Got subject journal successfully : ID {request.Id}.");

        return model;
    }
}