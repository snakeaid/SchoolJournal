using AutoMapper;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using SchoolJournal.BusinessLogic.Extensions;
using SchoolJournal.DataAccess;
using SchoolJournal.Primitives;

namespace SchoolJournal.StudentService;

/// <summary>
/// This student represents a MassTransit definition class which defines the behaviour
/// of <see cref="StudentDeleteModelConsumer"/> and implements <see cref="ConsumerDefinition{TConsumer}"/>
/// for <see cref="StudentDeleteModelConsumer"/>.
/// </summary>
public class StudentDeleteModelConsumerDefinition : ConsumerDefinition<StudentDeleteModelConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<StudentDeleteModelConsumer> consumerConfigurator)
    {
        endpointConfigurator.DiscardFaultedMessages();
    }
}

/// <summary>
/// This student represents a MassTransit consumer class which consumes messages to delete a student and implements
/// <see cref="IConsumer{TMessage}"/> for <see cref="StudentDeleteModel"/>.
/// </summary>
public class StudentDeleteModelConsumer : IConsumer<StudentDeleteModel>
{
    private readonly ApplicationContext _context;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructs an instance of <see cref="StudentDeleteModelConsumer"/> using the specified mapper, logger and context.
    /// </summary>
    /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
    /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/> for <see cref="StudentDeleteModelConsumer"/>.</param>
    /// <param name="context">An instance of <see cref="ApplicationContext"/>.</param>
    public StudentDeleteModelConsumer(IMapper mapper, ILogger<StudentDeleteModelConsumer> logger,
        ApplicationContext context)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// Consumes the message.
    /// </summary>
    /// <param name="context">An instance of <see cref="ConsumeContext{T}"/> for <see cref="StudentDeleteModel"/>.</param>
    public async Task Consume(ConsumeContext<StudentDeleteModel> context)
    {
        var model = context.Message;

        var entity = await _context.CompleteStudents().FirstOrDefaultAsync(x => x.Id == model.Id);
        if (entity == null) throw new KeyNotFoundException($"Student NOT FOUND : ID {model.Id}.");

        entity.DateTimeDeleted = LocalDateTime.FromDateTime(DateTime.Now);
        _context.Update(entity);
        await _context.SaveChangesAsync();

        _logger.LogInformation($"Deleted student successfully : ID {entity.Id}.");

        await context.RespondAsync(_mapper.Map<StudentViewModel>(entity));
    }
}