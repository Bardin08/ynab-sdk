using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YnabNet;

public static class ServiceCollectionExtensions
{
    public static void AddYnabClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IUserApiClient, UserApiClient>(client =>
        {
            client.BaseAddress = new Uri("https://api.ynab.com/v1/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", configuration.GetSection(YnabSection.SectionName)["Pat"]);
        }).AddStandardResilienceHandler();

        services.AddHttpClient<IBudgetApiClient, BudgetApiClient>(client =>
        {
            client.BaseAddress = new Uri("https://api.ynab.com/v1/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", configuration.GetSection(YnabSection.SectionName)["Pat"]);
        }).AddStandardResilienceHandler();

        services.AddHttpClient<IAccountApiClient, AccountsApiClient>(client =>
        {
            client.BaseAddress = new Uri("https://api.ynab.com/v1/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", configuration.GetSection(YnabSection.SectionName)["Pat"]);
        }).AddStandardResilienceHandler();

        services.AddHttpClient<ICategoryApiClient, CategoryApiClient>(client =>
        {
            client.BaseAddress = new Uri("https://api.ynab.com/v1/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", configuration.GetSection(YnabSection.SectionName)["Pat"]);
        }).AddStandardResilienceHandler();

        services.AddHttpClient<IPayeeApiClient, PayeeApiClient>(client =>
        {
            client.BaseAddress = new Uri("https://api.ynab.com/v1/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", configuration.GetSection(YnabSection.SectionName)["Pat"]);
        }).AddStandardResilienceHandler();

        services.AddHttpClient<ITransactionApiClient, TransactionApiClient>(client =>
        {
            client.BaseAddress = new Uri("https://api.ynab.com/v1/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", configuration.GetSection(YnabSection.SectionName)["Pat"]);
        }).AddStandardResilienceHandler();

        services.AddSingleton<IYnabClient, YnabClient>();
    }
}
