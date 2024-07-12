using YnabNet.Extensions;
using YnabNet.Models.Requests;
using YnabNet.Models.Response;

namespace YnabNet;

public interface ITransactionApiClient
{
    Task<ListTransactionsResponse?> GetAll(TransactionsRequest request);
    Task<SingleTransactionResponse?> Get(Guid budgetId, string transactionId);
    Task<SingleTransactionResponse?> Delete(Guid budgetId, string transactionId);

    Task<CreatedTransactionResponse?> Create(
        Guid budgetId,
        TransactionCreateRequest<TransactionPayload> request);

    Task<SingleTransactionResponse?> Update(
        Guid budgetId,
        string transactionId,
        TransactionUpdateRequest<TransactionPayload> request);

    Task<SingleTransactionResponse?> BulkUpdate(
        Guid budgetId,
        TransactionUpdateRequest<TransactionPayload> request);
}

public class TransactionApiClient(HttpClient httpClient) : ITransactionApiClient
{
    public Task<ListTransactionsResponse?> GetAll(TransactionsRequest request)
    {
        var endpoint = $"budgets/{request.BudgetId}/transactions";
        var queryParameters = new Dictionary<string, string?>
        {
            { "since_date", request.SinceDate.ToString() },
            { "type", request.Type },
            { "last_knowledge_of_server", request.LastKnowledgeOfServer.ToString() }
        };
        return httpClient.Get<ListTransactionsResponse?>(endpoint, queryParameters);
    }

    public Task<SingleTransactionResponse?> Get(Guid budgetId, string transactionId)
    {
        var endpoint = $"budgets/{budgetId}/transactions/{transactionId}";
        return httpClient.Get<SingleTransactionResponse?>(endpoint);
    }

    public Task<SingleTransactionResponse?> Delete(Guid budgetId, string transactionId)
    {
        var endpoint = $"budgets/{budgetId}/transactions/{transactionId}";
        return httpClient.Delete<SingleTransactionResponse?>(endpoint);
    }

    public Task<CreatedTransactionResponse?> Create(Guid budgetId, TransactionCreateRequest<TransactionPayload> request)
    {
        var endpoint = $"budgets/{budgetId}/transactions";
        return httpClient
            .Post<TransactionCreateRequest<TransactionPayload>, CreatedTransactionResponse?>(endpoint, request);
    }

    public Task<SingleTransactionResponse?> Update(
        Guid budgetId,
        string transactionId,
        TransactionUpdateRequest<TransactionPayload> request)
    {
        if (request.Transaction is null)
            throw new ArgumentNullException(nameof(request.Transaction),
                "This method requires a non-null Transaction property on the request object.");

        var endpoint = $"budgets/{budgetId}/transactions/{transactionId}";
        return httpClient
            .Put<TransactionUpdateRequest<TransactionPayload>, SingleTransactionResponse?>(endpoint, request);
    }

    public Task<SingleTransactionResponse?> BulkUpdate(
        Guid budgetId,
        TransactionUpdateRequest<TransactionPayload> request)
    {
        if (request.Transactions is null)
            throw new ArgumentNullException(nameof(request.Transactions),
                "This method requires a non-null Transactions property on the request object.");

        var endpoint = $"budgets/{budgetId}/transactions";
        return httpClient
            .Patch<TransactionUpdateRequest<TransactionPayload>, SingleTransactionResponse?>(endpoint, request);
    }
}
