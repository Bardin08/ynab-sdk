namespace YnabNet.Models.Requests;

public record AccountTransactionsRequest(
    string BudgetId,
    string AccountId,
    DateOnly SinceDate,
    string Type,
    long? LastKnowledgeOfServer);
