using CardanOrleans.Server;
using CardOrelans.Server.Services;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using System.Net;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddTransient<IGetTransactionsFromKois, GetTransactionsFromKois>();
        await StartSilo();
        builder.Services.AddSingleton<ClusterClientHostedService>();
        builder.Services.AddSingleton<IHostedService>(sp => sp.GetRequiredService<ClusterClientHostedService>());
        builder.Services.AddSingleton(sp => sp.GetRequiredService<ClusterClientHostedService>().Client);
        builder.Services.Configure<ConsoleLifetimeOptions>(sp => sp.SuppressStatusMessages = true);


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
    private static async Task StartSilo()
    {
        // define the cluster configuration
        var host = new HostBuilder()
           .UseOrleans(builder =>
           {
               builder.UseLocalhostClustering();
               builder.AddMemoryGrainStorageAsDefault();
               })
            .Build();

        await host.StartAsync();
        Console.WriteLine("The silo has started");
    }

}




