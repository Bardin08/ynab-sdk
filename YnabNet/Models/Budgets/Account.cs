namespace YnabNet.Models.Budgets;

public class Account
{
    public required string Id { get; set; }
    public required string Name { get; set; }

    // TODO: replace with enum
    public required string Type { get; set; }

    public string? TransferPayeeId { get; set; }
    public string? Note { get; set; }

    public int Balance { get; set; }
    public int ClearedBalance { get; set; }
    public int UnclearedBalance { get; set; }

    public bool DirectImportLinked { get; set; }
    public bool DirectImportInError { get; set; }

    public DateTime? LastReconciledAt { get; set; }

    public decimal? DebtOriginalBalance { get; set; }
    public Dictionary<string, long>? DebtInterestRates { get; set; }
    public Dictionary<string, long>? DebtMinimumPayments { get; set; }
    public Dictionary<string, long>? DebtEscrowAmounts { get; set; }

    public bool OnBudget { get; set; }
    public bool Closed { get; set; }
    public bool Deleted { get; set; }
}
