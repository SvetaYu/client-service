namespace ClientComponent;

public interface IClientComponent
{
    Task<KeyValuePair?> Get(string key);
    Task<KeyValuePair?> Set(string key, string value);
}