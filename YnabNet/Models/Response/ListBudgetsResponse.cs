using YnabNet.Models.Budgets;

namespace YnabNet.Models.Response;

public class ListBudgetsResponse
{
    public required List<BudgetSummary> Budgets { get; set; }
    public BudgetSummary? DefaultBudget { get; set; }
}
