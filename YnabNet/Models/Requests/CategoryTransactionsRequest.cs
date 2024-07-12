namespace YnabNet.Models.Requests;

public record CategoryTransactionsRequest(
    string BudgetId,
    string CategoryId,
    DateOnly SinceDate,
    string Type,
    long? LastKnowledgeOfServer);