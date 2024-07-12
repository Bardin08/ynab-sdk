namespace YnabNet.Models.Requests;

public record TransactionCreateRequest<TPayload>
{
    public required TPayload Transaction { get; init; }
}