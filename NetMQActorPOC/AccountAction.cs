namespace NetMQActorPOC
{
    public enum TransactionType { Debit = 1, Credit = 2 }

    public class AccountAction
    {
        public AccountAction(TransactionType transactionType, decimal amount)
        {
            TransactionType = transactionType;
            Amount = amount;
        }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        
        public override string ToString()
        {
            return string.Format("Transaction Type: {0}, Amount: {1} ",TransactionType, Amount);
        }
        
    }
}