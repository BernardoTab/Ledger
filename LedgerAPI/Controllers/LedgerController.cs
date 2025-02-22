using AutoMapper;
using Ledger.DataTransferring.Transactions;
using Ledger.Entities.Transactions;
using Ledger.Services.Ledgers;
using Microsoft.AspNetCore.Mvc;

namespace Ledger.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class LedgerController : ControllerBase
    {
        private readonly IMapper _dtoMapper;
        private readonly ILedgerService _ledgerService;

        public LedgerController(
            IMapper dtoMapper,
            ILedgerService ledgerService)
        {
            _dtoMapper = dtoMapper;
            _ledgerService = ledgerService;
        }

        [HttpGet("balance")]
        public IActionResult GetBalance()
        {
            decimal balance = _ledgerService.GetBalance();
            return Ok(balance);
        }

        [HttpPost("transactions")]
        public IActionResult CreateTransaction(TransactionWriteDto transactionToWrite)
        {
            Transaction transaction = _dtoMapper.Map<Transaction>(transactionToWrite);
            Transaction result = _ledgerService.CreateTransaction(transaction);
            return Ok(result);
        }

        [HttpGet("transactions")]
        public IActionResult GetTransactionHistory()
        {
            ICollection<Transaction> transactions = _ledgerService.GetTransactionHistory();
            ICollection<TransactionReadDto> transactionDtos = _dtoMapper.Map<ICollection<TransactionReadDto>>(transactions);
            return Ok(transactionDtos);
        }
    }
}
