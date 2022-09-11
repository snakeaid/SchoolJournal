using MassTransit;
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
/// This class represents a MassTransit consumer class which consumes messages to create a product and implements
/// <see cref="IConsumer{TMessage}"/> for
/// <see cref="ClassCreateModel"/>.
/// </summary>
public class ClassCreateModelConsumer : IConsumer<ClassCreateModel>
{
    /// <summary>
    /// Consumes the message.
    /// </summary>
    /// <param name="context">An instance of <see cref="ConsumeContext{T}"/> for <see cref="ClassCreateModel"/>.</param>
    public Task Consume(ConsumeContext<ClassCreateModel> context)
    {
        throw new NotImplementedException();
    }
}