using YnabNet.Models.Transactions;

namespace YnabNet.Models.Response;

public record SinglePayeeLocationResponse
{
    public required PayeeLocation PayeeLocations { get; set; }
}