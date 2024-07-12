using YnabNet.Extensions;
using YnabNet.Models.Requests;
using YnabNet.Models.Response;

namespace YnabNet;

public interface ICategoryApiClient
{
    Task<ListCategoriesResponse?> GetAll(string budgetId, long? token);
    Task<SingleCategoryResponse?> Get(string budgetId, string categoryId);
    Task<ListTransactionsResponse?> GetTransactions(CategoryTransactionsRequest request);

    Task<SingleCategoryResponse?> GetForMonth(Guid budgetId, DateOnly month, Guid categoryId);

    Task<SingleCategoryResponse?> Update(
        string budgetId, string categoryId, CategoryUpdateRequest<CategoryUpdatePayload> request);

    Task<SingleCategoryResponse?> UpdateMonthBudgeted(string budgetId, DateOnly month, Guid categoryId,
        CategoryUpdateRequest<CategoryUpdateMonthBudgetPayload> request);
}

public class CategoryApiClient(HttpClient httpClient) : ICategoryApiClient
{
    public async Task<ListCategoriesResponse?> GetAll(string budgetId, long? token)
    {
        var endpoint = $"budgets/{budgetId}/categories";
        var queryParameters = new Dictionary<string, string?> { { "last_knowledge_of_server", token.ToString() } };
        return await httpClient.Get<ListCategoriesResponse>(endpoint, queryParameters);
    }

    public Task<SingleCategoryResponse?> Get(string budgetId, string categoryId)
    {
        var endpoint = $"budgets/{budgetId}/categories/{categoryId}";
        return httpClient.Get<SingleCategoryResponse?>(endpoint);
    }

    public Task<ListTransactionsResponse?> GetTransactions(CategoryTransactionsRequest request)
    {
        var endpoint = $"budgets/{request.BudgetId}/categories/{request.CategoryId}/transactions";
        var queryParameters = new Dictionary<string, string?>
        {
            { "since_date", request.SinceDate.ToString() },
            { "type", request.Type },
            { "last_knowledge_of_server", request.LastKnowledgeOfServer.ToString() }
        };

        return httpClient.Get<ListTransactionsResponse>(endpoint, queryParameters);
    }

    public Task<SingleCategoryResponse?> GetForMonth(Guid budgetId, DateOnly month, Guid categoryId)
    {
        var endpoint = $"budgets/{budgetId}/months/{month:yyyy-MM-dd}/categories/{categoryId}";
        return httpClient.Get<SingleCategoryResponse?>(endpoint);
    }

    public Task<SingleCategoryResponse?> Update(
        string budgetId, string categoryId, CategoryUpdateRequest<CategoryUpdatePayload> request)
    {
        var endpoint = $"budgets/{budgetId}/categories/{categoryId}";
        return httpClient
            .Patch<CategoryUpdateRequest<CategoryUpdatePayload>, SingleCategoryResponse?>(endpoint, request);
    }

    public Task<SingleCategoryResponse?> UpdateMonthBudgeted(string budgetId, DateOnly month, Guid categoryId,
        CategoryUpdateRequest<CategoryUpdateMonthBudgetPayload> request)
    {
        var endpoint = $"budgets/{budgetId}/months/{month:yyyy-MM-dd}/categories/{categoryId}";
        return httpClient
            .Patch<CategoryUpdateRequest<CategoryUpdateMonthBudgetPayload>, SingleCategoryResponse?>(endpoint, request);
    }
}
