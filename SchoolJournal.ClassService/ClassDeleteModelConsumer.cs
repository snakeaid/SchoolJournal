using AutoMapper;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using SchoolJournal.BusinessLogic.Extensions;
using SchoolJournal.DataAccess;
using SchoolJournal.Primitives;

namespace SchoolJournal.ClassService;

/// <summary>
/// This class represents a MassTransit definition class which defines the behaviour
/// of <see cref="ClassDeleteModelConsumer"/> and implements <see cref="ConsumerDefinition{TConsumer}"/>
/// for <see cref="ClassDeleteModelConsumer"/>.
/// </summary>
public class ClassDeleteModelConsumerDefinition : ConsumerDefinition<ClassDeleteModelConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<ClassDeleteModelConsumer> consumerConfigurator)
    {
        endpointConfigurator.DiscardFaultedMessages();
    }
}

/// <summary>
/// This class represents a MassTransit consumer class which consumes messages to delete a class and implements
/// <see cref="IConsumer{TMessage}"/> for <see cref="ClassDeleteModel"/>.
/// </summary>
public class ClassDeleteModelConsumer : IConsumer<ClassDeleteModel>
{
    private readonly ApplicationContext _context;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructs an instance of <see cref="ClassDeleteModelConsumer"/> using the specified mapper, logger and context.
    /// </summary>
    /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
    /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/> for <see cref="ClassDeleteModelConsumer"/>.</param>
    /// <param name="context">An instance of <see cref="ApplicationContext"/>.</param>
    public ClassDeleteModelConsumer(IMapper mapper, ILogger<ClassDeleteModelConsumer> logger,
        ApplicationContext context)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// Consumes the message.
    /// </summary>
    /// <param name="context">An instance of <see cref="ConsumeContext{T}"/> for <see cref="ClassDeleteModel"/>.</param>
    public async Task Consume(ConsumeContext<ClassDeleteModel> context)
    {
        var model = context.Message;

        var entity = await _context.CompleteClasses().FirstOrDefaultAsync(x => x.Id == model.Id);
        if (entity == null) throw new KeyNotFoundException($"Class NOT FOUND : ID {model.Id}.");

        entity.DateTimeDeleted = LocalDateTime.FromDateTime(DateTime.Now);
        _context.Update(entity);
        await _context.SaveChangesAsync();

        _logger.LogInformation($"Deleted class successfully : ID {entity.Id}.");

        await context.RespondAsync(_mapper.Map<ClassViewModel>(entity));
    }
}