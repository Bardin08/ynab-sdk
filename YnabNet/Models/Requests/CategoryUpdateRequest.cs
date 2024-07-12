namespace YnabNet.Models.Requests;

public record CategoryUpdateRequest<TPayload>
{
    public required TPayload Category { get; set; }
}

public record CategoryUpdatePayload
{
    public Guid CategoryGroupId { get; set; }
    public required string Name { get; set; }
    public string? Note { get; set; }
}

public record CategoryUpdateMonthBudgetPayload
{
    public long Budgeted { get; init; }
}
