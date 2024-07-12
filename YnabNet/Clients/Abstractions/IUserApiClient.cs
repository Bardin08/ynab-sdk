namespace YnabNet;

public interface IUserApiClient
{
    public Task<string> GetId();
}