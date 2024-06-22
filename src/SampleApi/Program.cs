using SampleApi.Endpoints;
using SampleApi.Persistence;

namespace SampleApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        {
            var services = builder.Services;
            var configuration = builder.Configuration;

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x => x.CustomSchemaIds(type => type.ToString().Replace('+', '.')));

            services.AddOptions<MongoDbSettings>()
                .Bind(configuration.GetSection(nameof(MongoDbSettings)))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services.AddScoped<OrderRepository>();
        }

        var app = builder.Build();
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var groupBuilder = app
                .MapGroup("orders")
                .WithTags("Orders");

            groupBuilder
                .MapPost(string.Empty, CreateOrderEndpoint.Handle)
                .WithDescription("...")
                .WithOpenApi();

            groupBuilder
                .MapPost("{id:guid}/pay", PayOrderEndpoint.Handle)
                .WithDescription("...")
                .WithOpenApi();

            groupBuilder
                .MapPut("{id:guid}/address", UpdateOrderAddressEndpoint.Handle)
                .WithDescription("...")
                .WithOpenApi();

            groupBuilder
                .MapPut("{id:guid}/complete", CompleteOrderEndpoint.Handle)
                .WithDescription("...")
                .WithOpenApi();
        }

        app.Run();
    }
}