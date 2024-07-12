# YNAB SDK

A pure REST client for You Need A Budget (YNAB) that gives you an integration for endpoints using resilient HTTP
clients and the .NET HttpClient with no external dependencies.

## Features

- Comprehensive integration with YNAB endpoints.
- Resilient HTTP client implementation.
- Pure .NET HttpClient usage.
- No external dependencies.

## Installation

To install YNAB SDK, use the following NuGet command:

```shell
dotnet add package YnabSdk
```

## Usage

### Initialization

To initialize the YNAB SDK, you need to provide your YNAB API token:

```csharp
using YnabNet;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddYnabClient(builder.Configuration);
```

```json
{
  "YNAB": {
    "Pat": "YNAB_API_TOKEN"
  }
}
```
> [!TIP]
> Here you can find the [YNAB API token](https://app.youneedabudget.com/settings/developer).

### Example: Get Budgets

To get a list of budgets, use the following code:

```csharp
var budgets = await ynabClient.Budgets.GetAll();
foreach (var budget in budgets)
{
    Console.WriteLine($"Budget: {budget.Name}");
}
```

## Contributing

Contributions are welcome! Please submit a pull request or open an issue to discuss your ideas.

## License

This project is licensed under the MIT License.
