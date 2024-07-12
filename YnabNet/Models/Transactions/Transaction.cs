namespace YnabNet.Models.Transactions;

public record Transaction
{
    public string Id { get; set; }
    public string AccountId { get; set; }
    public int Amount { get; set; }
    public bool Approved { get; set; }
    public string Cleared { get; set; }
    public DateTime Date { get; set; }
    public string Memo { get; set; }
    public string FlagColor { get; set; }
    public string FlagName { get; set; }
    public string PayeeId { get; set; }
    public string CategoryId { get; set; }
    public string TransferAccountId { get; set; }
    public string TransferTransactionId { get; set; }
    public string MatchedTransactionId { get; set; }
    public string ImportId { get; set; }
    public string ImportPayeeName { get; set; }
    public string ImportPayeeNameOriginal { get; set; }
    public string DebtTransactionType { get; set; }
    public bool Deleted { get; set; }

    public List<SubTransaction>? SubTransactions { get; set; }
}

public record SubTransaction
{
    public string Id { get; set; }
    public string TransactionId { get; set; }
    public long Amount { get; set; }
    public string Memo { get; set; }

    public Guid PayeeId { get; set; }
    public string PayeeName { get; set; }

    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }

    public Guid TransferAccountId { get; set; }
    public string TransferTransactionId { get; set; }

    public bool Deleted { get; set; }
}

public record ScheduledTransactions
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }

    public long Amount { get; set; }
    public string Memo { get; set; }
    public string FlagName { get; set; }
    public string FlagColor { get; set; }

    // TODO: Replace with enum
    public string Frequency { get; set; }

    public Guid PayeeId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid TransferAccountId { get; set; }

    public DateOnly DateFirst { get; set; }
    public DateOnly DateNext { get; set; }

    public bool Deleted { get; set; }
}

public record ScheduledSubTransactions
{
    public Guid Id { get; set; }
    public Guid ScheduledTransactionId { get; set; }
    public long Amount { get; set; }
    public string Memo { get; set; }

    public Guid PayeeId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid TransferAccountId { get; set; }

    public bool Deleted { get; set; }
}
