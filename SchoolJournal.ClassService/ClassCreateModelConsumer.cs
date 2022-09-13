using AutoMapper;
using FluentValidation;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SchoolJournal.BusinessLogic.Extensions;
using SchoolJournal.DataAccess;
using SchoolJournal.DataAccess.Primitives;
using SchoolJournal.Primitives;

namespace SchoolJournal.ClassService;

/// <summary>
/// This class represents a MassTransit definition class which defines the behaviour
/// of <see cref="ClassCreateModelConsumer"/> and implements <see cref="ConsumerDefinition{TConsumer}"/>
/// for <see cref="ClassCreateModelConsumer"/>.
/// </summary>
public class ClassCreateModelConsumerDefinition : ConsumerDefinition<ClassCreateModelConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<ClassCreateModelConsumer> consumerConfigurator)
    {
        endpointConfigurator.DiscardFaultedMessages();
    }
}

/// <summary>
/// This class represents a MassTransit consumer class which consumes messages to create a class and implements
/// <see cref="IConsumer{TMessage}"/> for
/// <see cref="ClassCreateModel"/>.
/// </summary>
public class ClassCreateModelConsumer : IConsumer<ClassCreateModel>
{
    private readonly ApplicationContext _context;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IValidator<ClassCreateModel> _validator;

    /// <summary>
    /// Constructs an instance of <see cref="ClassCreateModelConsumer"/> using the specified mapper, validator, logger and context.
    /// </summary>
    /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
    /// <param name="validator">An instance of <see cref="IValidator{T}"/> for <see cref="ClassCreateModel"/>.</param>
    /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/> for <see cref="ClassCreateModelConsumer"/>.</param>
    /// <param name="context">An instance of <see cref="ApplicationContext"/>.</param>
    public ClassCreateModelConsumer(IMapper mapper, IValidator<ClassCreateModel> validator,
        ILogger<ClassCreateModelConsumer> logger, ApplicationContext context)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
        _validator = validator;
    }

    /// <summary>
    /// Consumes the message.
    /// </summary>
    /// <param name="context">An instance of <see cref="ConsumeContext{T}"/> for <see cref="ClassCreateModel"/>.</param>
    public async Task Consume(ConsumeContext<ClassCreateModel> context)
    {
        var model = context.Message;
        await _validator.ValidateAndThrowAsync(model);

        var entity = _mapper.Map<Class>(model);
        await _context.Classes.AddAsync(entity);
        await _context.SaveChangesAsync();
        entity = await _context.CompleteClasses().FirstOrDefaultAsync(x => x.Id == entity.Id);

        _logger.LogInformation($"Added new class successfully : ID {entity!.Id}.");

        await context.RespondAsync(_mapper.Map<ClassViewModel>(entity));
    }
}