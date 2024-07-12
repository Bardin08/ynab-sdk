using YnabNet.Models.Requests;
using YnabNet.Models.Response;

namespace YnabNet;

public interface IAccountApiClient
{
    Task<ListAccountsResponse?> GetAll(string budgetId, long? token);
    Task<SingleAccountResponse?> Get(string budgetId, string accountId);
    Task<ListTransactionsResponse?> GetTransactions(AccountTransactionsRequest request);

    Task<SingleAccountResponse?> Create(string budgetId, AccountCreateRequest request);
}
