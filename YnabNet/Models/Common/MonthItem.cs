namespace YnabNet.Models.Common;

public record MonthItem
{
    public long Activity { get; init; }
    public DateOnly Month { get; init; }

    public long Budgeted { get; init; }
    public long Income { get; init; }
    public long ToBeBudgeted { get; init; }

    public string? Note { get; init; }
    public int? AgeOfMoney { get; init; }

    public bool Deleted { get; init; }

    /// <summary>
    /// This represents the categories for the month
    /// If months were queried throw the <code>/budgets/:budgetId/months</code> will be empty
    /// </summary>
    public List<MonthCategory>? Categories { get; init; }
}
