using Ledger.Services.Balances.Queries;
using Ledger.Services.Implementations.Common;
using Microsoft.AspNetCore.Mvc;

namespace Ledger.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBalanceAsync(
            [FromServices] IQueryHandler<GetBalanceQuery, decimal> getBalanceQueryHandler)
        {
            GetBalanceQuery query = new GetBalanceQuery();
            decimal balance = await getBalanceQueryHandler.HandleAsync(query);
            return Ok(balance);
        }
    }
}
