using YnabNet.Models.Budgets;

namespace YnabNet.Models.Response;

public class ListAccountsResponse
{
    public required List<Account> Accounts { get; set; }
    public int ServerKnowledge { get; init; }
}
