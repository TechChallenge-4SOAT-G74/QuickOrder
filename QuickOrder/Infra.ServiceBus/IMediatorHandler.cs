using FluentValidation.Results;
using Infra.ServiceBus.Messaging;

namespace Infra.ServiceBus
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;

        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
