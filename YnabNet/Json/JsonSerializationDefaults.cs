using System.Text.Json;
using System.Text.Json.Serialization;

namespace YnabNet.Json;

public static class JsonSerializationDefaults
{
    public static JsonSerializerOptions DefaultOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        NumberHandling = JsonNumberHandling.AllowReadingFromString |
                         JsonNumberHandling.AllowNamedFloatingPointLiterals,
        WriteIndented = false,
        AllowTrailingCommas = false
    };
}
