using YnabNet.Extensions;
using YnabNet.Models.Response;

namespace YnabNet;

/// <inheritdoc />
public class BudgetApiClient(HttpClient httpClient) : IBudgetApiClient
{
    public async Task<ListBudgetsResponse?> GetAll(bool includeAccounts = false)
    {
        const string endpoint = "budgets";

        var queryParameters = new Dictionary<string, string?> { { "include_accounts", includeAccounts.ToString() } };
        return await httpClient.Get<ListBudgetsResponse>(endpoint, queryParameters);
    }

    public async Task<SingleBudgetResponse?> Get(string budgetId, long? token)
    {
        var endpoint = $"budgets/{budgetId}";

        var queryParameters = new Dictionary<string, string?> { { "last_knowledge_of_server", token.ToString() } };
        return await httpClient.Get<SingleBudgetResponse?>(endpoint, queryParameters);
    }

    public Task<BudgetSettingsResponse?> GetSettings(string budgetId)
    {
        var endpoint = $"budgets/{budgetId}/settings";
        return httpClient.Get<BudgetSettingsResponse?>(endpoint);
    }

    public Task<ListBudgetMonthsResponse?> GetMonths(string budgetId, long? token)
    {
        var endpoint = $"budgets/{budgetId}/months";
        var queryParameters = new Dictionary<string, string?> { { "last_knowledge_of_server", token.ToString() } };
        return httpClient.Get<ListBudgetMonthsResponse?>(endpoint, queryParameters);
    }

    public Task<SingleBudgetMonthResponse?> GetMonth(string budgetId, DateOnly month)
    {
        var endpoint = $"budgets/{budgetId}/months/{month:yyyy-MM-dd}";
        return httpClient.Get<SingleBudgetMonthResponse?>(endpoint);
    }
}
