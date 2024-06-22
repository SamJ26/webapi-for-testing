using SampleApi.Endpoints;

namespace SampleApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        var app = builder.Build();
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var groupBuilder = app.MapGroup("orders");

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