using YnabNet.Models.Transactions;

namespace YnabNet.Models.Response;

public record SingleTransactionResponse
{
    public required Transaction Transaction { get; set; }
}
