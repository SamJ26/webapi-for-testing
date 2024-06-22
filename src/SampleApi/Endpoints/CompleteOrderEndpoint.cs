using Microsoft.AspNetCore.Mvc;
using SampleApi.Persistence;

namespace SampleApi.Endpoints;

internal sealed class CompleteOrderEndpoint
{
    public static async Task<IResult> Handle(
        [AsParameters] Request req,
        [FromServices] OrderRepository repository)
    {
        var order = await repository.FindAsync(req.Id);
        order.Complete();
        await repository.UpdateAsync(order);
        return TypedResults.Ok();
    }

    public sealed record Request
    {
        [FromRoute]
        public required Guid Id { get; init; }
    }
}