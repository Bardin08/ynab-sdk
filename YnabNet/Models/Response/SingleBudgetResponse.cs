using YnabNet.Models.Budgets;

namespace YnabNet.Models.Response;

public record SingleBudgetResponse
{
    public required Budget Budget { get; init; }
    public int ServerKnowledge { get; init; }
}
