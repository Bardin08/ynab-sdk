using YnabNet.Models.Categories;
using YnabNet.Models.Common;
using YnabNet.Models.Transactions;

namespace YnabNet.Models.Budgets;

public class Budget : BudgetSummary
{
    public List<Payee> Payees { get; set; }
    public List<PayeeLocation> PayeeLocations { get; set; }

    public List<MonthItem> Months { get; set; }
    public List<Transaction> Transactions { get; set; }

    public List<Category> Categories { get; set; }
    public List<CategoryGroup> CategoryGroups { get; set; }

    public List<SubTransaction> Subtransactions { get; set; }
    public List<ScheduledTransactions> ScheduledTransactions { get; set; }
    public List<ScheduledSubTransactions> ScheduledSubtransactions { get; set; }
}
