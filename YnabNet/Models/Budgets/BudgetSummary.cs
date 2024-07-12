using YnabNet.Models.Common;

namespace YnabNet.Models.Budgets;

public class BudgetSummary
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required List<Account> Accounts { get; set; }

    public DateFormat? DateFormat { get; set; }
    public CurrencyFormat? CurrencyFormat { get; set; }

    public DateTime LastModifiedOn { get; set; }
    public DateOnly FirstMonth { get; set; }
    public DateOnly LastMonth { get; set; }
}
