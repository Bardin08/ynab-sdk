namespace YnabNet.Models.Response;

internal record ApiResponse<TBody>
{
    public TBody? Data { get; init; }
    public Error? Error { get; init; }
}

internal record Error
{
    public string Detail { get; init; }
    public string Id { get; init; }
    public string Name { get; init; }
}
