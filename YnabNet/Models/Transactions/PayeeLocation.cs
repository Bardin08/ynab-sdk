namespace YnabNet.Models.Transactions;

public record PayeeLocation
{
    public Guid Id { get; init; }
    public required Guid PayeeId { get; init; }
    public required string Latitude { get; init; }
    public required string Longitude { get; init; }
    public bool Deleted { get; init; }
}
