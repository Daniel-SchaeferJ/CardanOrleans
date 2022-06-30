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
        builder.Services.AddTransient<IGetTransactionsFromKoisGrain, GetTransactionsFromKoisGrain>();
        await StartSilo(); 
        await StartSilo2();

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
    private static async Task<ISiloHost> StartSilo()
    {
        // define the cluster configuration
        var builder = new SiloHostBuilder()
            .UseLocalhostClustering()
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "dev";
                options.ServiceId = "CardanOrleans";
            })
             .Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback)
            .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(GetTransactionsFromKoisGrain).Assembly).WithReferences())
            .ConfigureLogging(logging => logging.AddConsole())
            .AddMemoryGrainStorage("CardanOrleans");

        var host = builder.Build();
        await host.StartAsync();
        return host;
    }

    private static async Task<ISiloHost> StartSilo2()
    {
        // define the cluster configuration
        var builder = new SiloHostBuilder()
            .UseLocalhostClustering()
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "dev";
                options.ServiceId = "CardanOrleans";
            })
            .Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback)
            .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(GetTransactionsFromKoisGrain).Assembly).WithReferences())
            .ConfigureLogging(logging => logging.AddConsole())
            .AddMemoryGrainStorage("CardanOrleans");

        var host = builder.Build();
        await host.StartAsync();
        return host;
    }
}




