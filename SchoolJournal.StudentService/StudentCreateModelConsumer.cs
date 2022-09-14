using AutoMapper;
using FluentValidation;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SchoolJournal.BusinessLogic.Extensions;
using SchoolJournal.DataAccess;
using SchoolJournal.DataAccess.Primitives;
using SchoolJournal.Primitives;

namespace SchoolJournal.StudentService;

/// <summary>
/// This student represents a MassTransit definition class which defines the behaviour
/// of <see cref="StudentCreateModelConsumer"/> and implements <see cref="ConsumerDefinition{TConsumer}"/>
/// for <see cref="StudentCreateModelConsumer"/>.
/// </summary>
public class StudentCreateModelConsumerDefinition : ConsumerDefinition<StudentCreateModelConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<StudentCreateModelConsumer> consumerConfigurator)
    {
        endpointConfigurator.DiscardFaultedMessages();
    }
}

/// <summary>
/// This student represents a MassTransit consumer class which consumes messages to create a student and implements
/// <see cref="IConsumer{TMessage}"/> for
/// <see cref="StudentCreateModel"/>.
/// </summary>
public class StudentCreateModelConsumer : IConsumer<StudentCreateModel>
{
    private readonly ApplicationContext _context;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IValidator<StudentCreateModel> _validator;

    /// <summary>
    /// Constructs an instance of <see cref="StudentCreateModelConsumer"/> using the specified mapper, validator, logger and context.
    /// </summary>
    /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
    /// <param name="validator">An instance of <see cref="IValidator{T}"/> for <see cref="StudentCreateModel"/>.</param>
    /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/> for <see cref="StudentCreateModelConsumer"/>.</param>
    /// <param name="context">An instance of <see cref="ApplicationContext"/>.</param>
    public StudentCreateModelConsumer(IMapper mapper, IValidator<StudentCreateModel> validator,
        ILogger<StudentCreateModelConsumer> logger, ApplicationContext context)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
        _validator = validator;
    }

    /// <summary>
    /// Consumes the message.
    /// </summary>
    /// <param name="context">An instance of <see cref="ConsumeContext{T}"/> for <see cref="StudentCreateModel"/>.</param>
    public async Task Consume(ConsumeContext<StudentCreateModel> context)
    {
        var model = context.Message;
        await _validator.ValidateAndThrowAsync(model);

        var entity = _mapper.Map<Student>(model);
        await _context.Students.AddAsync(entity);
        await _context.SaveChangesAsync();
        entity = await _context.CompleteStudents().FirstOrDefaultAsync(x => x.Id == entity.Id);

        _logger.LogInformation($"Added new student successfully : ID {entity!.Id}.");

        await context.RespondAsync(_mapper.Map<StudentViewModel>(entity));
    }
}