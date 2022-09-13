using AutoMapper;
using FluentValidation;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SchoolJournal.BusinessLogic.Extensions;
using SchoolJournal.DataAccess;
using SchoolJournal.Primitives;

namespace SchoolJournal.ClassService;

/// <summary>
/// This class represents a MassTransit definition class which defines the behaviour
/// of <see cref="ClassUpdateModelConsumer"/> and implements <see cref="ConsumerDefinition{TConsumer}"/>
/// for <see cref="ClassUpdateModelConsumer"/>.
/// </summary>
public class ClassUpdateModelConsumerDefinition : ConsumerDefinition<ClassUpdateModelConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<ClassUpdateModelConsumer> consumerConfigurator)
    {
        endpointConfigurator.DiscardFaultedMessages();
    }
}

/// <summary>
/// This class represents a MassTransit consumer class which consumes messages to update a class and implements
/// <see cref="IConsumer{TMessage}"/> for <see cref="ClassUpdateModel"/>.
/// </summary>
public class ClassUpdateModelConsumer : IConsumer<ClassUpdateModel>
{
    private readonly ApplicationContext _context;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IValidator<ClassUpdateModel> _validator;

    /// <summary>
    /// Constructs an instance of <see cref="ClassUpdateModelConsumer"/> using the specified mapper, logger, validator and context.
    /// </summary>
    /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
    /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/> for <see cref="ClassUpdateModelConsumer"/>.</param>
    /// <param name="context">An instance of <see cref="ApplicationContext"/>.</param>
    /// <param name="validator">An instance of <see cref="IValidator{T}"/> for <see cref="ClassUpdateModel"/>.</param>
    public ClassUpdateModelConsumer(IMapper mapper, ILogger<ClassUpdateModelConsumer> logger,
        ApplicationContext context, IValidator<ClassUpdateModel> validator)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
        _validator = validator;
    }

    /// <summary>
    /// Consumes the message.
    /// </summary>
    /// <param name="context">An instance of <see cref="ConsumeContext{T}"/> for <see cref="ClassUpdateModel"/>.</param>
    public async Task Consume(ConsumeContext<ClassUpdateModel> context)
    {
        var model = context.Message;

        var entity = await _context.CompleteClasses().FirstOrDefaultAsync(x => x.Id == model.Id);
        if (entity == null) throw new KeyNotFoundException($"Class NOT FOUND : ID {model.Id}.");

        await _validator.ValidateAndThrowAsync(model);

        _mapper.Map(source: model, destination: entity);
        _context.Update(entity); //TODO: Add update for students list
        await _context.SaveChangesAsync();

        _logger.LogInformation($"Updated class successfully : ID {entity.Id}.");

        await context.RespondAsync(_mapper.Map<ClassViewModel>(entity));
    }
}