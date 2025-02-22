using Ledger.Services.Common.Commands;

namespace Ledger.Services.Implementations.Common.Validations
{
    public class ValidatedCommandHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandValidator<TCommand> _commandValidator;
        private readonly ICommandHandler<TCommand> _commandHandler;

        public ValidatedCommandHandler(
            ICommandValidator<TCommand> commandValidator,
            ICommandHandler<TCommand> commandHandler)
        {
            _commandValidator = commandValidator;
            _commandHandler = commandHandler;
        }

        public async Task HandleAsync(TCommand command)
        {
            await _commandValidator.ValidateAsync(command);
            await _commandHandler.HandleAsync(command);
        }
    }
}
