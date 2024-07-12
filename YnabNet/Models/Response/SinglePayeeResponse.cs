using YnabNet.Models.Transactions;

namespace YnabNet.Models.Response;

public record SinglePayeeResponse
{
    public required Payee Payee { get; set; }
    /// <summary>
    /// Returned from the PATCH request, after payee update.
    /// </summary>
    public long ServerKnowledge { get; set; }
}