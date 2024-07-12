namespace YnabNet.Models.Categories;

public class Category
{
    public Guid Id { get; set; }
    public Guid CategoryGroupId { get; set; }
    public Guid? OriginalCategoryGroupId { get; set; }

    public required string CategoryGroupName { get; set; }
    public required string Name { get; set; }
    public string? Note { get; set; }

    // TODO: update to enum
    public string? GoalType { get; set; }

    public int Budgeted { get; set; }
    public int Activity { get; set; }
    public int Balance { get; set; }

    public bool? GoalNeedsWholeAmount { get; set; }
    public int? GoalDay { get; set; }
    public int? GoalCadence { get; set; }
    public int? GoalCadenceFrequency { get; set; }

    public DateOnly? GoalCreationMonth { get; set; }

    public long GoalTarget { get; set; }
    public DateOnly? GoalTargetMonth { get; set; }

    public int? GoalPercentageComplete { get; set; }
    public int? GoalMonthsToBudget { get; set; }
    public long? GoalUnderFunded { get; set; }
    public long? GoalOverallFunded { get; set; }
    public long? GoalOverallLeft { get; set; }

    public bool Hidden { get; set; }
    public bool Deleted { get; set; }
}
