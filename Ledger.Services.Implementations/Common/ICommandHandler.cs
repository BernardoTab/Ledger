using Ledger.Services.Common.Commands;

namespace Ledger.Services.Implementations.Common
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
