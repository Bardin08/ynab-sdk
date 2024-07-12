using YnabNet.Extensions;
using YnabNet.Models.Requests;
using YnabNet.Models.Response;

namespace YnabNet;

public interface IPayeeApiClient
{
    Task<ListPayeesResponse?> GetPayees(Guid budgetId, long? token);
    Task<SinglePayeeResponse?> GetPayee(Guid budgetId, Guid payeeId);
    Task<SinglePayeeResponse?> Update(Guid budgetId, Guid payeeId, PayeeUpdateRequest<PayeeUpdatePayload> request);
    Task<ListTransactionsResponse?> GetTransactions(PayeeTransactionsRequest request);
    Task<SinglePayeeLocationResponse?> GetLocation(Guid budgetId, Guid locationId);
    Task<ListPayeeLocationsResponse?> GetLocations(Guid budgetId);
    Task<ListPayeeLocationsResponse?> GetLocations(Guid budgetId, Guid payeeId);
}

public class PayeeApiClient(HttpClient httpClient) : IPayeeApiClient
{
    public Task<ListPayeesResponse?> GetPayees(Guid budgetId, long? token)
    {
        var endpoint = $"budgets/{budgetId}/payees";
        var queryParameters = new Dictionary<string, string?> { { "last_knowledge_of_server", token.ToString() } };
        return httpClient.Get<ListPayeesResponse?>(endpoint, queryParameters);
    }

    public Task<SinglePayeeResponse?> GetPayee(Guid budgetId, Guid payeeId)
    {
        var endpoint = $"budgets/{budgetId}/payees/{payeeId}";
        return httpClient.Get<SinglePayeeResponse?>(endpoint);
    }

    public Task<SinglePayeeResponse?> Update(
        Guid budgetId, Guid payeeId, PayeeUpdateRequest<PayeeUpdatePayload> request)
    {
        var endpoint = $"budgets/{budgetId}/payees/{payeeId}";
        return httpClient
            .Patch<PayeeUpdateRequest<PayeeUpdatePayload>, SinglePayeeResponse?>(endpoint, request);
    }

    public Task<ListTransactionsResponse?> GetTransactions(PayeeTransactionsRequest request)
    {
        var endpoint = $"budgets/{request.BudgetId}/payees/{request.PayeeId}/transactions";
        var queryParameters = new Dictionary<string, string?>
        {
            { "since_date", request.SinceDate.ToString() },
            { "type", request.Type },
            { "last_knowledge_of_server", request.LastKnowledgeOfServer.ToString() }
        };

        return httpClient.Get<ListTransactionsResponse?>(endpoint, queryParameters);
    }

    public Task<SinglePayeeLocationResponse?> GetLocation(Guid budgetId, Guid locationId)
    {
        var endpoint = $"budgets/{budgetId}/payee_locations/{locationId}";
        return httpClient.Get<SinglePayeeLocationResponse?>(endpoint);
    }

    public Task<ListPayeeLocationsResponse?> GetLocations(Guid budgetId)
    {
        var endpoint = $"budgets/{budgetId}/payee_locations";
        return httpClient.Get<ListPayeeLocationsResponse?>(endpoint);
    }

    public Task<ListPayeeLocationsResponse?> GetLocations(Guid budgetId, Guid payeeId)
    {
        var endpoint = $"budgets/{budgetId}/payees/{payeeId}/payee_locations";
        return httpClient.Get<ListPayeeLocationsResponse?>(endpoint);
    }
}
