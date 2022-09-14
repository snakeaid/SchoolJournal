using AutoMapper;
using FluentValidation;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SchoolJournal.BusinessLogic.Extensions;
using SchoolJournal.DataAccess;
using SchoolJournal.Primitives;

namespace SchoolJournal.StudentService;

/// <summary>
/// This student represents a MassTransit definition class which defines the behaviour
/// of <see cref="StudentUpdateModelConsumer"/> and implements <see cref="ConsumerDefinition{TConsumer}"/>
/// for <see cref="StudentUpdateModelConsumer"/>.
/// </summary>
public class StudentUpdateModelConsumerDefinition : ConsumerDefinition<StudentUpdateModelConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<StudentUpdateModelConsumer> consumerConfigurator)
    {
        endpointConfigurator.DiscardFaultedMessages();
    }
}

/// <summary>
/// This student represents a MassTransit consumer class which consumes messages to update a student and implements
/// <see cref="IConsumer{TMessage}"/> for <see cref="StudentUpdateModel"/>.
/// </summary>
public class StudentUpdateModelConsumer : IConsumer<StudentUpdateModel>
{
    private readonly ApplicationContext _context;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IValidator<StudentUpdateModel> _validator;

    /// <summary>
    /// Constructs an instance of <see cref="StudentUpdateModelConsumer"/> using the specified mapper, logger, validator and context.
    /// </summary>
    /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
    /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/> for <see cref="StudentUpdateModelConsumer"/>.</param>
    /// <param name="context">An instance of <see cref="ApplicationContext"/>.</param>
    /// <param name="validator">An instance of <see cref="IValidator{T}"/> for <see cref="StudentUpdateModel"/>.</param>
    public StudentUpdateModelConsumer(IMapper mapper, ILogger<StudentUpdateModelConsumer> logger,
        ApplicationContext context, IValidator<StudentUpdateModel> validator)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
        _validator = validator;
    }

    /// <summary>
    /// Consumes the message.
    /// </summary>
    /// <param name="context">An instance of <see cref="ConsumeContext{T}"/> for <see cref="StudentUpdateModel"/>.</param>
    public async Task Consume(ConsumeContext<StudentUpdateModel> context)
    {
        var model = context.Message;

        var entity = await _context.CompleteStudents().FirstOrDefaultAsync(x => x.Id == model.Id);
        if (entity == null) throw new KeyNotFoundException($"Student NOT FOUND : ID {model.Id}.");

        await _validator.ValidateAndThrowAsync(model);

        _mapper.Map(source: model, destination: entity);
        _context.Update(entity);
        await _context.SaveChangesAsync();

        _logger.LogInformation($"Updated student successfully : ID {entity.Id}.");

        await context.RespondAsync(_mapper.Map<StudentViewModel>(entity));
    }
}