namespace YnabNet.Models.Requests;

public record PayeeTransactionsRequest(
    Guid BudgetId,
    Guid PayeeId,
    DateOnly SinceDate,
    string Type,
    long? LastKnowledgeOfServer);
