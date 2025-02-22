using AutoMapper;
using Ledger.DataTransferring.Transactions;
using Ledger.Entities.Transactions;
using Ledger.Services.Balances.Queries;
using Ledger.Services.Implementations.Common;
using Ledger.Services.Transactions.Commands;
using Ledger.Services.Transactions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Ledger.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class LedgerController : ControllerBase
    {
        private readonly IMapper _dtoMapper;

        public LedgerController(
            IMapper dtoMapper)
        {
            _dtoMapper = dtoMapper;
        }

        [HttpGet("balance")]
        public IActionResult GetBalance(
            [FromServices] IQueryHandler<GetBalanceQuery, decimal> getBalanceQueryHandler)
        {
            GetBalanceQuery query = new GetBalanceQuery();
            decimal balance = getBalanceQueryHandler.Handle(query);
            return Ok(balance);
        }

        [HttpPost("transactions")]
        public IActionResult CreateTransaction(
            TransactionWriteDto transactionToWrite,
            [FromServices] ICommandHandler<CreateTransactionCommand> createTransactionCommandHandler)
        {
            Transaction transaction = _dtoMapper.Map<Transaction>(transactionToWrite);
            CreateTransactionCommand command = new CreateTransactionCommand
            {
                Transaction = transaction
            };
            createTransactionCommandHandler.Handle(command);
            return NoContent();
        }

        [HttpGet("transactions")]
        public IActionResult GetTransactionHistory(
            [FromServices] IQueryHandler<GetTransactionHistoryQuery, ICollection<Transaction>> getTransactionHistoryQueryHandler)
        {
            GetTransactionHistoryQuery query = new GetTransactionHistoryQuery();
            ICollection<Transaction> transactions = getTransactionHistoryQueryHandler.Handle(query);
            ICollection<TransactionReadDto> transactionDtos = _dtoMapper.Map<ICollection<TransactionReadDto>>(transactions);
            return Ok(transactionDtos);
        }
    }
}
