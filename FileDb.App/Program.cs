using FileDb.App.Services.Identities;

internal class Program
{
    private static void Main(string[] args)
    {
        IdentitiyService identitiyService = IdentitiyService.GetInstance();
        Console.WriteLine(identitiyService.GetNewId());
    
    }
}