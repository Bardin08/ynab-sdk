namespace YnabNet;

public interface IYnabClient
{
    IUserApiClient User { get; set; }
    IBudgetApiClient Budgets { get; set; }
    IAccountApiClient Accounts { get; set; }
    ICategoryApiClient Categories { get; set; }
    IPayeeApiClient Payees { get; set; }
    ITransactionApiClient Transactions { get; set; }
}
