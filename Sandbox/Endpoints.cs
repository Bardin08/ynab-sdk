using Microsoft.AspNetCore.Mvc;
using YnabNet;
using YnabNet.Models.Requests;

namespace Sandbox;

public static class Endpoints
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        app.MapGet("/user", async ([FromServices] IYnabClient ynabClient) =>
        {
            var id = await ynabClient.User.GetId();
            return Results.Ok(id);
        });

        app.MapGet("/budgets", async (HttpRequest request, [FromServices] IYnabClient ynabClient) =>
        {
            if (!bool.TryParse(request.Query["include_accounts"], out var includeAccounts))
            {
                return Results.BadRequest();
            }

            var id = await ynabClient.Budgets.GetAll(includeAccounts);
            return Results.Ok(id);
        });


        app.MapGet("/budgets/{budgetId}", async ([FromRoute] string budgetId,
            HttpRequest request, [FromServices] IYnabClient ynabClient) =>
        {
            var tokenPassed = !long.TryParse(request.Query["last_knowledge_of_server"], out var lastServerKnowledge);

            var budget = await ynabClient.Budgets.Get(budgetId, tokenPassed ? lastServerKnowledge : null);
            return Results.Ok(budget);
        });

        app.MapGet("/budgets/{budgetId}/settings",
            async ([FromRoute] string budgetId, [FromServices] IYnabClient ynabClient) =>
            {
                var budget = await ynabClient.Budgets.GetSettings(budgetId);
                return Results.Ok(budget);
            });

        app.MapGet("/budgets/{budgetId}/accounts", async ([FromRoute] string budgetId,
            HttpRequest request, [FromServices] IYnabClient ynabClient) =>
        {
            var tokenPassed = !long.TryParse(request.Query["last_knowledge_of_server"], out var lastServerKnowledge);

            var budget = await ynabClient.Accounts.GetAll(budgetId, tokenPassed ? lastServerKnowledge : null);
            return Results.Ok(budget);
        });

        app.MapPost("/budgets/{budgetId}/accounts", async (
            [FromRoute] string budgetId,
            [FromBody] AccountCreateRequest request,
            [FromServices] IYnabClient ynabClient) =>
        {
            var budget = await ynabClient.Accounts.Create(budgetId, request);
            return Results.Ok(budget);
        });

        app.MapGet("/budgets/{budgetId}/accounts/{accountId}", async (
            [FromRoute] string budgetId,
            [FromRoute] string accountId,
            [FromServices] IYnabClient ynabClient) =>
        {
            var budget = await ynabClient.Accounts.Get(budgetId, accountId);
            return Results.Ok(budget);
        });

        app.MapGet("/budgets/{budgetId}/accounts/{accountId}/transactions", async (
            [FromRoute] string budgetId,
            [FromRoute] string accountId,
            HttpRequest request,
            [FromServices] IYnabClient ynabClient) =>
        {
            var tokenPassed = !long.TryParse(request.Query["last_knowledge_of_server"], out var lastServerKnowledge);
            var type = string.IsNullOrEmpty(request.Query["type"]) ? "uncategorized" : request.Query["type"].First();

            var sinceDateQueryParam = request.Query["since_date"].FirstOrDefault();
            var customDate = DateOnly.TryParse(sinceDateQueryParam, out var sinceDate)
                ? sinceDate
                : DateOnly.FromDateTime(DateTime.Now.AddMonths(-1));

            var ynabRequest = new AccountTransactionsRequest(
                budgetId,
                accountId,
                customDate,
                type!,
                tokenPassed ? lastServerKnowledge : null);

            var budget = await ynabClient.Accounts.GetTransactions(ynabRequest);
            return Results.Ok(budget);
        });

        app.MapGet("/budgets/{budgetId}/categories", async (
            [FromRoute] string budgetId,
            HttpRequest request,
            [FromServices] IYnabClient ynabClient) =>
        {
            var tokenPassed = !long.TryParse(request.Query["last_knowledge_of_server"], out var lastServerKnowledge);

            var budget = await ynabClient.Categories.GetAll(budgetId, tokenPassed ? lastServerKnowledge : null);
            return Results.Ok(budget);
        });

        app.MapGet("/budgets/{budgetId}/categories/{categoryId}", async (
            [FromRoute] string budgetId,
            [FromRoute] string categoryId,
            [FromServices] IYnabClient ynabClient) =>
        {
            var budget = await ynabClient.Categories.Get(budgetId, categoryId);
            return Results.Ok(budget);
        });

        app.MapGet("/budgets/{budgetId}/categories/{categoryId}/transactions", async (
            [FromRoute] string budgetId,
            [FromRoute] string categoryId,
            HttpRequest request,
            [FromServices] IYnabClient ynabClient) =>
        {
            var tokenPassed = !long.TryParse(request.Query["last_knowledge_of_server"], out var lastServerKnowledge);
            var type = string.IsNullOrEmpty(request.Query["type"]) ? "uncategorized" : request.Query["type"].First();

            var sinceDateQueryParam = request.Query["since_date"].FirstOrDefault();
            var customDate = DateOnly.TryParse(sinceDateQueryParam, out var sinceDate)
                ? sinceDate
                : DateOnly.FromDateTime(DateTime.Now.AddMonths(-1));

            var ynabRequest = new CategoryTransactionsRequest(
                budgetId,
                categoryId,
                customDate,
                type!,
                tokenPassed ? lastServerKnowledge : null);

            var budget = await ynabClient.Categories.GetTransactions(ynabRequest);
            return Results.Ok(budget);
        });

        app.MapPatch("/budgets/{budgetId}/categories/{categoryId}", async (
            [FromRoute] string budgetId,
            [FromRoute] string categoryId,
            [FromBody] CategoryUpdateRequest<CategoryUpdatePayload> request,
            [FromServices] IYnabClient ynabClient) =>
        {
            var budget = await ynabClient.Categories.Update(budgetId, categoryId, request);
            return Results.Ok(budget);
        });

        app.MapGet("/budgets/{budgetId}/months", async (
            [FromRoute] string budgetId,
            HttpRequest request,
            [FromServices] IYnabClient ynabClient) =>
        {
            var tokenPassed = !long.TryParse(request.Query["last_knowledge_of_server"], out var lastServerKnowledge);

            var budget = await ynabClient.Budgets.GetMonths(budgetId, tokenPassed ? lastServerKnowledge : null);
            return Results.Ok(budget);
        });

        app.MapGet("/budgets/{budgetId}/months/{month}", async (
            [FromRoute] string budgetId,
            [FromRoute] DateOnly month,
            [FromServices] IYnabClient ynabClient) =>
        {
            var budget = await ynabClient.Budgets.GetMonth(budgetId, month);
            return Results.Ok(budget);
        });

        app.MapPatch("/budgets/{budgetId}/months/{month}/categories/{categoryId}", async (
            [FromRoute] string budgetId,
            [FromRoute] DateOnly month,
            [FromRoute] Guid categoryId,
            [FromBody] CategoryUpdateRequest<CategoryUpdateMonthBudgetPayload> request,
            [FromServices] IYnabClient ynabClient) =>
        {
            var budget = await ynabClient.Categories.UpdateMonthBudgeted(budgetId, month, categoryId, request);
            return Results.Ok(budget);
        });

        app.MapGet("/budgets/{budgetId}/months/{month}/categories/{categoryId}", async (
            [FromRoute] Guid budgetId,
            [FromRoute] DateOnly month,
            [FromRoute] Guid categoryId,
            [FromServices] IYnabClient ynabClient) =>
        {
            var budget = await ynabClient.Categories.GetForMonth(budgetId, month, categoryId);
            return Results.Ok(budget);
        });

        #region Payee API client

        app.MapGet("/budgets/{budgetId:guid}/payees", async (
            [FromRoute] Guid budgetId,
            HttpRequest request,
            [FromServices] IYnabClient ynabClient) =>
        {
            var tokenPassed = !long.TryParse(request.Query["last_knowledge_of_server"], out var lastServerKnowledge);

            var payees = await ynabClient.Payees.GetPayees(budgetId, tokenPassed ? lastServerKnowledge : null);
            return Results.Ok(payees);
        });

        app.MapGet("/budgets/{budgetId:guid}/payees/{payeeId:guid}", async (
            [FromRoute] Guid budgetId,
            [FromRoute] Guid payeeId,
            [FromServices] IYnabClient ynabClient) =>
        {
            var payee = await ynabClient.Payees.GetPayee(budgetId, payeeId);
            return Results.Ok(payee);
        });

        // List payee transactions
        app.MapGet("/budgets/{budgetId:guid}/payees/{payeeId:guid}/transactions", async (
            [FromRoute] Guid budgetId,
            [FromRoute] Guid payeeId,
            HttpRequest request,
            [FromServices] IYnabClient ynabClient) =>
        {
            var tokenPassed = !long.TryParse(request.Query["last_knowledge_of_server"], out var lastServerKnowledge);
            var type = string.IsNullOrEmpty(request.Query["type"]) ? "uncategorized" : request.Query["type"].First();

            var sinceDateQueryParam = request.Query["since_date"].FirstOrDefault();
            var customDate = DateOnly.TryParse(sinceDateQueryParam, out var sinceDate)
                ? sinceDate
                : DateOnly.FromDateTime(DateTime.Now.AddMonths(-1));

            var ynabRequest = new PayeeTransactionsRequest(
                budgetId,
                payeeId,
                customDate,
                type!,
                tokenPassed ? lastServerKnowledge : null);

            var transactions = await ynabClient.Payees.GetTransactions(ynabRequest);
            return Results.Ok(transactions);
        });

        app.MapGet("/budgets/{budgetId:guid}/payees/{payeeId:guid}/payee_locations", async (
            [FromRoute] Guid budgetId,
            [FromRoute] Guid payeeId,
            [FromServices] IYnabClient ynabClient) =>
        {
            var locations = await ynabClient.Payees.GetLocations(budgetId, payeeId);
            return Results.Ok(locations);
        });

        // Update payee
        app.MapPatch("/budgets/{budgetId:guid}/payees/{payeeId:guid}", async (
            [FromRoute] Guid budgetId,
            [FromRoute] Guid payeeId,
            [FromBody] PayeeUpdateRequest<PayeeUpdatePayload> request,
            [FromServices] IYnabClient ynabClient) =>
        {
            var payee = await ynabClient.Payees.Update(budgetId, payeeId, request);
            return Results.Ok(payee);
        });

        app.MapGet("/budgets/{budgetId:guid}/payee_locations", async (
            [FromRoute] Guid budgetId,
            [FromServices] IYnabClient ynabClient) =>
        {
            var budget = await ynabClient.Payees.GetLocations(budgetId);
            return Results.Ok(budget);
        });

        app.MapGet("/budgets/{budgetId:guid}/payee_locations/{payeeId:guid}", async (
            [FromRoute] Guid budgetId,
            [FromRoute] Guid payeeId,
            [FromServices] IYnabClient ynabClient) =>
        {
            var budget = await ynabClient.Payees.GetLocation(budgetId, payeeId);
            return Results.Ok(budget);
        });

        #endregion

        #region Transaction API client

        app.MapGet("/budgets/{budgetId:guid}/transactions", async (
            [FromRoute] Guid budgetId,
            HttpRequest request,
            [FromServices] IYnabClient ynabClient) =>
        {
            var tokenPassed = !long.TryParse(request.Query["last_knowledge_of_server"], out var lastServerKnowledge);

            var type = string.IsNullOrEmpty(request.Query["type"]) ? "uncategorized" : request.Query["type"].First();

            var sinceDateQueryParam = request.Query["since_date"].FirstOrDefault();
            var customDate = DateOnly.TryParse(sinceDateQueryParam, out var sinceDate)
                ? sinceDate
                : DateOnly.FromDateTime(DateTime.Now.AddMonths(-1));

            var ynabRequest = new TransactionsRequest(
                budgetId,
                customDate,
                type!,
                tokenPassed ? lastServerKnowledge : null);

            var transactions = await ynabClient.Transactions.GetAll(ynabRequest);
            return Results.Ok(transactions);
        });

        app.MapGet("/budgets/{budgetId:guid}/transactions/{transactionId}", async (
            [FromRoute] Guid budgetId,
            [FromRoute] string transactionId,
            [FromServices] IYnabClient ynabClient) =>
        {
            var transaction = await ynabClient.Transactions.Get(budgetId, transactionId);
            return Results.Ok(transaction);
        });

        app.MapDelete("/budgets/{budgetId:guid}/transactions/{transactionId}", async (
            [FromRoute] Guid budgetId,
            [FromRoute] string transactionId,
            [FromServices] IYnabClient ynabClient) =>
        {
            var transaction = await ynabClient.Transactions.Delete(budgetId, transactionId);
            return Results.Ok(transaction);
        });

        app.MapPost("/budgets/{budgetId:guid}/transactions", async (
            [FromRoute] Guid budgetId,
            [FromBody] TransactionCreateRequest<TransactionPayload> request,
            [FromServices] IYnabClient ynabClient) =>
        {
            var transaction = await ynabClient.Transactions.Create(budgetId, request);
            return Results.Ok(transaction);
        });

        app.MapPut("/budgets/{budgetId:guid}/transactions/{transactionId}", async (
            [FromRoute] Guid budgetId,
            [FromRoute] string transactionId,
            [FromBody] TransactionUpdateRequest<TransactionPayload> request,
            [FromServices] IYnabClient ynabClient) =>
        {
            var transaction = await ynabClient.Transactions.Update(budgetId, transactionId, request);
            return Results.Ok(transaction);
        });

        app.MapPatch("/budgets/{budgetId:guid}/transactions", async (
            [FromRoute] Guid budgetId,
            [FromRoute] string transactionId,
            [FromBody] TransactionUpdateRequest<TransactionPayload> request,
            [FromServices] IYnabClient ynabClient) =>
        {
            var transaction = await ynabClient.Transactions.BulkUpdate(budgetId, request);
            return Results.Ok(transaction);
        });

        #endregion
    }
}
