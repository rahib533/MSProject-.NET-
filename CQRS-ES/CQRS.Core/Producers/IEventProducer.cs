using CQRS.Core.Events;

namespace CQRS.Core.Producers
{
    public interface IEventProducer
    {
         Task ProducerAsync<T>(string topic, T @event) where T : BaseEvent;
    }
}