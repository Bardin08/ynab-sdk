using System.Transactions;

namespace YnabNet.Models.Response;

public record ListTransactionsResponse
{
    public required List<Transaction> Transactions { get; set; }
    public long? ServerKnowledge { get; set; }
}
