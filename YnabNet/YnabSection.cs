namespace YnabNet;

public record YnabSection
{
    public const string SectionName = "YNAB";

    public required string Pat { get; init; }
}
