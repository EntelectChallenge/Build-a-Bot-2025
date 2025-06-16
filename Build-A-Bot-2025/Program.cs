using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Load configuration from appsettings.json
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
        var configuration = builder.Build();

        // Read values from config or environment
        var ip = Environment.GetEnvironmentVariable("RUNNER_IPV4") ?? configuration["RunnerIP"];
        if (!ip.StartsWith("http://")) ip = $"http://{ip}";

        var port = configuration["RunnerPort"];
        var nickname = Environment.GetEnvironmentVariable("BOT_NICKNAME") ?? configuration["BotNickname"];
        var token = Environment.GetEnvironmentVariable("Token") ?? Environment.GetEnvironmentVariable("REGISTRATION_TOKEN");

        var url = $"{ip}:{port}/bothub";

        // Create SignalR connection
        var connection = new HubConnectionBuilder()
            .WithUrl(url)
            .ConfigureLogging(logging => logging.SetMinimumLevel(LogLevel.Debug))
            .WithAutomaticReconnect()
            .Build();

        // Connect!
        await connection.StartAsync();
        Console.WriteLine("Connected to Runner");
    }
}

