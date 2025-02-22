using AutoMapper;
using Ledger.DataTransferring.Transactions;
using Ledger.Entities.Transactions;
using Ledger.Services.Implementations.Common;
using Ledger.Services.Transactions.Commands;
using Ledger.Services.Transactions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Ledger.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMapper _dtoMapper;

        public TransactionsController(
            IMapper dtoMapper)
        {
            _dtoMapper = dtoMapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransactionAsync(
            TransactionWriteDto transactionToWrite,
            [FromServices] ICommandHandler<CreateTransactionCommand> createTransactionCommandHandler)
        {
            Transaction transaction = _dtoMapper.Map<Transaction>(transactionToWrite);
            CreateTransactionCommand command = new CreateTransactionCommand
            {
                Transaction = transaction
            };
            await createTransactionCommandHandler.HandleAsync(command);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactionHistoryAsync(
            [FromServices] IQueryHandler<GetTransactionHistoryQuery, ICollection<Transaction>> getTransactionHistoryQueryHandler)
        {
            GetTransactionHistoryQuery query = new GetTransactionHistoryQuery();
            ICollection<Transaction> transactions = await getTransactionHistoryQueryHandler.HandleAsync(query);
            ICollection<TransactionReadDto> transactionDtos = _dtoMapper.Map<ICollection<TransactionReadDto>>(transactions);
            return Ok(transactionDtos);
        }
    }
}
