using Ledger.Services.Common.Commands;

namespace Ledger.Services.Implementations.Common
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
