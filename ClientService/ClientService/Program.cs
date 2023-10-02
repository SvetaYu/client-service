class Program
{
    static void Main(string[] args)
    {
        if (args.Length.Equals(0)) throw new Exception();
        switch (args[0])
        {
            case "get":
                //Console.Writeline(ClientComponent.Get(args[1]))
                break;
            case "set":
                // ClientComponent.Set(args[1], args[2])
                break;
            default:
                throw new Exception();
        }
    }
}