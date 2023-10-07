using ClientComponent;
using KeyValuePair = ClientComponent.KeyValuePair;

namespace ClientService;

public static class Program
{
    private static readonly IClientComponent ClientComponent = new ClientComponent.ClientComponent("https://172.20.10.5:5430");

    public static async Task Main(string[] args)
    {
        
        if (args.Length.Equals(0)) throw new Exception();

        KeyValuePair? pair;
        switch (args[0])
        {
            case "get":
                pair = await ClientComponent.Get(args[1]);
                Console.WriteLine(pair?.Value);
                break;
            case "set":
                pair = await ClientComponent.Set(args[1], args[2]);
                Console.WriteLine("Set pair:");
                Console.WriteLine($"key={pair?.Key}");
                Console.WriteLine($"value={pair?.Value}");
                break;
            default:
                throw new Exception();
        }
    }
}