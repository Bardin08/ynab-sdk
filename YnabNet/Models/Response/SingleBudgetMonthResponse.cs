using YnabNet.Models.Common;

namespace YnabNet.Models.Response;

public record SingleBudgetMonthResponse
{
    public required List<MonthItem> Month { get; init; }
}