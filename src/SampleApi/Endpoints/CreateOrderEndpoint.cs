using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SampleApi.Domain;
using SampleApi.Persistence;

namespace SampleApi.Endpoints;

internal sealed class CreateOrderEndpoint
{
    public static async Task<Ok<Response>> Handle([FromServices] OrderRepository repository)
    {
        var order = new OrderEntity();
        await repository.CreateAsync(order);
        return TypedResults.Ok(new Response(order.Id));
    }

    public sealed record Response(Guid OrderId);
}