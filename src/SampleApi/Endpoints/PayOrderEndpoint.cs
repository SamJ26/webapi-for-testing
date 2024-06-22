using Microsoft.AspNetCore.Mvc;
using SampleApi.Persistence;

namespace SampleApi.Endpoints;

internal sealed class PayOrderEndpoint
{
    public static async Task<IResult> Handle(
        [AsParameters] Request req,
        [FromServices] OrderRepository repository)
    {
        var order = await repository.FindAsync(req.Id);
        order.Pay(req.Body.PaymentId);
        await repository.UpdateAsync(order);
        return TypedResults.Ok();
    }

    public sealed record Request
    {
        [FromRoute]
        public required Guid Id { get; init; }

        [FromBody]
        public required RequestBody Body { get; init; }

        public record RequestBody(Guid PaymentId);
    }
}