﻿using Ledger.Services.Common.Commands;

namespace Ledger.Services.Implementations.Common.Validations
{
    public interface ICommandValidator<TCommand>
        where TCommand : ICommand
    {
        Task ValidateAsync(TCommand command);
    }
}
