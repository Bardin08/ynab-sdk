namespace YnabNet.Models.Requests;

public record TransactionsRequest(
    Guid BudgetId,
    DateOnly SinceDate,
    string Type,
    long? LastKnowledgeOfServer);
