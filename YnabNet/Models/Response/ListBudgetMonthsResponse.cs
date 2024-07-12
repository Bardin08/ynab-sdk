using YnabNet.Models.Common;

namespace YnabNet.Models.Response;

public record ListBudgetMonthsResponse
{
    public required List<MonthItem> Months { get; init; }
    public long ServerKnowledge { get; init; }
}
