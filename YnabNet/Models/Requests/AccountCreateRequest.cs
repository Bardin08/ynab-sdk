namespace YnabNet.Models.Requests;

public record AccountCreateRequest
{
    public required AccountCreateData Account { get; set; }

    public record AccountCreateData
    {
        public long Balance { get; set; }
        public required string Name { get; set; }

        // TODO: update to enum
        public required string Type { get; set; }
    }
}
