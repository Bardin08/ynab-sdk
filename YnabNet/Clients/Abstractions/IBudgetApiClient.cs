using YnabNet.Models.Response;

namespace YnabNet;

public interface IBudgetApiClient
{
    Task<ListBudgetsResponse?> GetAll(bool includeAccounts = false);
    Task<SingleBudgetResponse?> Get(string budgetId, long? token);
    Task<BudgetSettingsResponse?> GetSettings(string budgetId);
    Task<ListBudgetMonthsResponse?> GetMonths(string budgetId, long? token);

    /// <summary>
    /// </summary>
    /// <param name="budgetId"></param>
    /// <param name="month">
    /// The budget month in ISO format (e.g., 2016-12-01) ("current" can also be used to specify the current calendar month (UTC)).
    /// </param>
    /// <returns></returns>
    Task<SingleBudgetMonthResponse?> GetMonth(string budgetId, DateOnly month);
}
