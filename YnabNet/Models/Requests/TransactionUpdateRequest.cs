namespace YnabNet.Models.Requests;

public record TransactionUpdateRequest<TPayload>
{
    public TPayload? Transaction { get; init; }
    public List<TPayload>? Transactions { get; set; }
}

public record TransactionPayload
{
    public Guid AccountId { get; init; }
    public DateOnly Date { get; init; }
    public required long Amount { get; init; }

    public Guid PayeeId { get; init; }
    public string? PayeeName { get; init; }

    public Guid CategoryId { get; init; }
    public string? Memo { get; init; }
    public string? Cleared { get; init; }
    public string? Approved { get; init; }
    public string? FlagColor { get; init; }
    public List<SubTransactionPayload>? SubTransactions { get; init; }
}

public record SubTransactionPayload
{
    public long Amount { get; init; }
    public Guid PayeeId { get; init; }
    public string? PayeeName { get; init; }
    public Guid CategoryId { get; init; }
    public string? Memo { get; init; }
}
