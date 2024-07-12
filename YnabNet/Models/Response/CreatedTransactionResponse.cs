
using YnabNet.Models.Transactions;

namespace YnabNet.Models.Response;

public record CreatedTransactionResponse
{
    public long ServerKnowledge { get; init; }
    public List<string>? TransactionIds { get; init; }
    public Transaction? Transaction { get; init; }
    public List<Transaction>? Transactions { get; init; }
    public List<string>? DuplicateImportIds { get; init; }
}
