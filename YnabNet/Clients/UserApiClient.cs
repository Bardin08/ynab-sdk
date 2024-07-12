using System.Net.Http.Json;
using YnabNet.Models.Response;

namespace YnabNet;

internal class UserApiClient(HttpClient httpClient) : IUserApiClient
{
    public async Task<string> GetId()
    {
        const string endpoint = "user";
        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<UserResponse>>();
        return apiResponse?.Data?.User.Id ?? throw new ArgumentException("User not found");
    }
}