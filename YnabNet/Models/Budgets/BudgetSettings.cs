using YnabNet.Models.Common;

namespace YnabNet.Models.Budgets;

public class BudgetSettings
{
    public required DateFormat DateFormat { get; set; }
    public required CurrencyFormat CurrencyFormat { get; set; }
}
