namespace YnabNet.Models.Common;

public record CurrencyFormat
{
    public int DecimalDigits { get; init; }

    public string? IsoCode { get; init; }
    public string? ExampleFormat { get; init; }
    public string? DecimalSeparator { get; init; }
    public string? GroupSeparator { get; init; }
    public string? CurrencySymbol { get; init; }

    public bool SymbolFirst { get; init; }
    public bool DisplaySymbol { get; init; }
}
