using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolJournal.BusinessLogic.Queries;
using SchoolJournal.DataAccess;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Handlers;

/// <summary>
/// MediatR handler class which handles the query to get all classes and
/// implements <see cref="IRequestHandler{TRequest,TResponse}"/> for
/// <see cref="GetAllClassesQuery"/>, <see cref="List{T}"/> for <see cref="ClassModel"/>.
/// </summary>
public class GetAllClassesHandler : IRequestHandler<GetAllClassesQuery, List<ClassModel>>
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructs an instance of <see cref="GetAllClassesHandler"/> using the specified context and mapper.
    /// </summary>
    /// <param name="context">An instance of <see cref="ApplicationContext"/>.</param>
    /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
    public GetAllClassesHandler(ApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ClassModel>> Handle(GetAllClassesQuery request, CancellationToken cancellationToken)
    {
        var list = await _context.Classes.ToListAsync();
        var listModel = _mapper.Map<List<ClassModel>>(list);

        return listModel;
    }
}