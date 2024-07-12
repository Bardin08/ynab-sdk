using YnabNet.Models.Transactions;

namespace YnabNet.Models.Response;

public record ListPayeeLocationsResponse
{
    public required List<PayeeLocation> PayeeLocations { get; init; }
}
