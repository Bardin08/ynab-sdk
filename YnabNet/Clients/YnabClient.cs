namespace YnabNet;

internal class YnabClient(
    IUserApiClient userApiClient,
    IBudgetApiClient budgetApiClient,
    IAccountApiClient accountApiClient,
    ICategoryApiClient categoryApiClient,
    IPayeeApiClient payeeApiClient,
    ITransactionApiClient transactionApiClient) : IYnabClient
{
    public IUserApiClient User { get; set; } = userApiClient;
    public IBudgetApiClient Budgets { get; set; } = budgetApiClient;
    public IAccountApiClient Accounts { get; set; } = accountApiClient;
    public ICategoryApiClient Categories { get; set; } = categoryApiClient;
    public IPayeeApiClient Payees { get; set; } = payeeApiClient;
    public ITransactionApiClient Transactions { get; set; } = transactionApiClient;
}
