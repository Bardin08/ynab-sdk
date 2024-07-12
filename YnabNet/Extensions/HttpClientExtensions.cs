using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;
using YnabNet.Json;
using YnabNet.Models.Exceptions;
using YnabNet.Models.Response;

namespace YnabNet.Extensions;

public static class HttpClientExtensions
{
    public static async Task<TResponse?> Get<TResponse>(
        this HttpClient client,
        string url,
        Dictionary<string, string?>? queryParameters = null,
        JsonSerializerOptions? jsonOptions = null)
        => await client.DoRequest<object, TResponse>(
            url,
            HttpMethod.Get,
            queryParameters,
            null,
            jsonOptions ?? JsonSerializationDefaults.DefaultOptions);

    public static async Task<TResponse?> Delete<TResponse>(
        this HttpClient client,
        string url,
        Dictionary<string, string?>? queryParameters = null,
        JsonSerializerOptions? jsonOptions = null)
        => await client.DoRequest<object, TResponse>(
            url,
            HttpMethod.Get,
            queryParameters,
            null,
            jsonOptions ?? JsonSerializationDefaults.DefaultOptions);

    public static async Task<TResponse?> Post<TRequest, TResponse>(
        this HttpClient client,
        string url,
        TRequest? requestBody,
        Dictionary<string, string?>? queryParameters = null,
        JsonSerializerOptions? jsonOptions = null)
        => await client.DoRequest<TRequest, TResponse>(
            url,
            HttpMethod.Post,
            queryParameters,
            requestBody,
            jsonOptions ?? JsonSerializationDefaults.DefaultOptions);

    public static async Task<TResponse?> Patch<TRequest, TResponse>(
        this HttpClient client,
        string url,
        TRequest? requestBody,
        Dictionary<string, string?>? queryParameters = null,
        JsonSerializerOptions? jsonOptions = null)
        => await client.DoRequest<TRequest, TResponse>(
            url,
            HttpMethod.Patch,
            queryParameters,
            requestBody,
            jsonOptions ?? JsonSerializationDefaults.DefaultOptions);

    public static async Task<TResponse?> Put<TRequest, TResponse>(
        this HttpClient client,
        string url,
        TRequest? requestBody,
        Dictionary<string, string?>? queryParameters = null,
        JsonSerializerOptions? jsonOptions = null)
        => await client.DoRequest<TRequest, TResponse>(
            url,
            HttpMethod.Put,
            queryParameters,
            requestBody,
            jsonOptions ?? JsonSerializationDefaults.DefaultOptions);

    private static async Task<TResponse?> DoRequest<TRequest, TResponse>(
        this HttpClient client,
        string url,
        HttpMethod method,
        Dictionary<string, string?>? queryParameters = null,
        TRequest? body = default,
        JsonSerializerOptions? jsonOptions = null)
    {
        var request = new HttpRequestMessage(method, BuildUrl(url, queryParameters))
        {
            Content = body is null
                ? null
                : new StringContent(JsonSerializer.Serialize(body, jsonOptions), Encoding.UTF8, "application/json")
        };

        var response = await client.SendAsync(request);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            var errorJson = await response.Content.ReadAsStringAsync();
            var error = JsonSerializer.Deserialize<ApiResponse<TResponse>>(errorJson, jsonOptions);
            throw new YnabException(error?.Error?.Detail, ex.InnerException);
        }

        var responseJson = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonSerializer.Deserialize<ApiResponse<TResponse>>(responseJson, jsonOptions);
        return apiResponse != null ? apiResponse.Data : default;
    }

    private static string BuildUrl(string endpoint, Dictionary<string, string?>? queryParameters)
    {
        return queryParameters is null ? endpoint : QueryHelpers.AddQueryString(endpoint, queryParameters);
    }
}
