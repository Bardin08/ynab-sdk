namespace YnabNet.Models.Requests;

public record PayeeUpdateRequest<TPayload>
{
    public required TPayload Payee { get; init; }
}

public record PayeeUpdatePayload
{
    public required string Name { get; init; }
}
