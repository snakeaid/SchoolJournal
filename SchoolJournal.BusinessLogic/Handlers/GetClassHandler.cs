using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructs an instance of <see cref="GetClassHandler"/> using the specified context and mapper.
    /// </summary>
    /// <param name="context">An instance of <see cref="ApplicationContext"/>.</param>
    /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
    public GetClassHandler(ApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ClassViewModel> Handle(GetClassQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Classes.Include(x => x.Students).Include(x => x.ClassTeacher)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"Class with ID {request.Id} NOT FOUND");
        var model = _mapper.Map<ClassViewModel>(entity);

        return model;
    }
}