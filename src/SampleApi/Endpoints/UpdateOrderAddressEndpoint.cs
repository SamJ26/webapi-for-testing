using Microsoft.AspNetCore.Mvc;
using SampleApi.Persistence;

namespace SampleApi.Endpoints;

internal sealed class UpdateOrderAddressEndpoint
{
    public static async Task<IResult> Handle(
        [AsParameters] Request req,
        [FromServices] OrderRepository repository)
    {
        var order = await repository.FindAsync(req.Id);
        order.UpdateDeliveryAddress(req.Body.Country, req.Body.City, req.Body.Street);
        await repository.UpdateAsync(order);
        return TypedResults.Ok();
    }

    public sealed record Request
    {
        [FromRoute]
        public required Guid Id { get; init; }

        [FromBody]
        public required RequestBody Body { get; init; }

        public record RequestBody(
            string Country,
            string City,
            string Street);
    }
}