using YnabNet.Extensions;
using YnabNet.Models.Requests;
using YnabNet.Models.Response;

namespace YnabNet;

public class AccountsApiClient(HttpClient httpClient) : IAccountApiClient
{
    public Task<ListAccountsResponse?> GetAll(string budgetId, long? token)
    {
        var endpoint = $"budgets/{budgetId}/accounts";
        var queryParameters = new Dictionary<string, string?> { { "last_knowledge_of_server", token.ToString() } };
        return httpClient.Get<ListAccountsResponse?>(endpoint, queryParameters);
    }

    public Task<SingleAccountResponse?> Get(string budgetId, string accountId)
    {
        var endpoint = $"budgets/{budgetId}/accounts/{accountId}";
        return httpClient.Get<SingleAccountResponse?>(endpoint);
    }

    public async Task<ListTransactionsResponse?> GetTransactions(AccountTransactionsRequest request)
    {
        var endpoint = $"budgets/{request.BudgetId}/accounts/{request.AccountId}/transactions";

        var queryParameters = new Dictionary<string, string?>
        {
            ["since_date"] = request.SinceDate.ToString("yyyy-MM-dd"),
            ["type"] = request.Type,
            ["last_knowledge_of_server"] = request.LastKnowledgeOfServer?.ToString()
        };

        return await httpClient.Get<ListTransactionsResponse>(endpoint, queryParameters);
    }

    public Task<SingleAccountResponse?> Create(string budgetId, AccountCreateRequest request)
    {
        var endpoint = $"budgets/{budgetId}/accounts";
        return httpClient.Post<AccountCreateRequest, SingleAccountResponse?>(endpoint, request);
    }
}
