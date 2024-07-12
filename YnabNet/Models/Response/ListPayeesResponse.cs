using YnabNet.Models.Transactions;

namespace YnabNet.Models.Response;

public record ListPayeesResponse
{
    public required List<Payee> Payees { get; set; }
    public long ServerKnowledge { get; set; }
}
