using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SampleApi.Domain.Exceptions;
using SampleApi.Persistence;

namespace SampleApi.Endpoints;

internal sealed class UpdateOrderAddressEndpoint
{
    public static async Task<Results<Ok, Conflict>> Handle(
        [AsParameters] Request req,
        [FromServices] OrderRepository repository,
        [FromServices] ILogger<UpdateOrderAddressEndpoint> logger)
    {
        var order = await repository.FindAsync(req.Id);

        try
        {
            order.UpdateDeliveryAddress(req.Body.Country, req.Body.City, req.Body.Street);
        }
        catch (InvalidOrderOperationException e)
        {
            logger.LogError(e, "Something bad happened :(");
            return TypedResults.Conflict();
        }

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