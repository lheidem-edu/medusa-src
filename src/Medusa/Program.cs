namespace Medusa;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel(options =>
        {
            options.ListenAnyIP(6980);
        });

        var application = builder.Build();
        application.Run();
    }
}
