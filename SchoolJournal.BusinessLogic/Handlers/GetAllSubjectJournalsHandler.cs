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
/// MediatR handler class which handles the query to get all subject journals and
/// implements <see cref="IRequestHandler{TRequest,TResponse}"/> for
/// <see cref="GetAllSubjectJournalsQuery"/>, <see cref="List{T}"/> for <see cref="SubjectJournalViewModel"/>.
/// </summary>
public class GetAllSubjectJournalsHandler : IRequestHandler<GetAllSubjectJournalsQuery, List<SubjectJournalViewModel>>
{
    private readonly ApplicationContext _context;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructs an instance of <see cref="GetAllSubjectJournalsHandler"/> using the specified context, mapper and logger.
    /// </summary>
    /// <param name="context">An instance of <see cref="ApplicationContext"/>.</param>
    /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
    /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/> for <see cref="GetAllSubjectJournalsHandler"/>.</param>
    public GetAllSubjectJournalsHandler(ApplicationContext context, IMapper mapper,
        ILogger<GetAllSubjectJournalsHandler> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Handles the specified request to get all subject journals.
    /// </summary>
    /// <param name="request">Request to get all subject journals.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><see cref="Task{TResult}"/> for <see cref="List{T}"/> for <see cref="SubjectJournalViewModel"/></returns>
    public async Task<List<SubjectJournalViewModel>> Handle(GetAllSubjectJournalsQuery request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting all subject journals.");
        var list = await _context.CompleteSubjectJournals().ToListAsync(cancellationToken);
        var listModel = _mapper.Map<List<SubjectJournalViewModel>>(list);
        _logger.LogInformation("Got all subject journals successfully.");

        return listModel;
    }
}