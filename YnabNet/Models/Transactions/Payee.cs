namespace YnabNet.Models.Transactions;

public record Payee
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string TransferAccountId { get; set; }
    public bool Deleted { get; set; }
}
