namespace YnabNet.Models.Common;

public class MonthCategory
{
    public string Id { get; set; }
    public string CategoryGroupId { get; set; }
    public string Name { get; set; }
    public bool Hidden { get; set; }
    public string OriginalCategoryGroupId { get; set; }
    public string Note { get; set; }
    public int Budgeted { get; set; }
    public int Activity { get; set; }
    public int Balance { get; set; }
    public string GoalType { get; set; }
    public bool? GoalNeedsWholeAmount { get; set; }
    public int? GoalDay { get; set; }
    public int? GoalCadence { get; set; }
    public int? GoalCadenceFrequency { get; set; }
    public string GoalCreationMonth { get; set; }
    public int? GoalTarget { get; set; }
    public string GoalTargetMonth { get; set; }
    public int? GoalPercentageComplete { get; set; }
    public int? GoalMonthsToBudget { get; set; }
    public int? GoalUnderFunded { get; set; }
    public int? GoalOverallFunded { get; set; }
    public int? GoalOverallLeft { get; set; }
    public bool Deleted { get; set; }
}