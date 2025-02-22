namespace Ledger.Entities.Exceptions
{
    public class BalanceIsInsufficientForWithdrawalException : Exception
    {
        public BalanceIsInsufficientForWithdrawalException(decimal transactionValue, decimal balance)
            : base($"The withdrawal of {transactionValue} is not possible as the current balance of ${balance} is insufficient")
        {
        }
    }
}
