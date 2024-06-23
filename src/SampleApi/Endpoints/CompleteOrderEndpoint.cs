using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SampleApi.Domain.Exceptions;
using SampleApi.Persistence;

namespace SampleApi.Endpoints;

internal sealed class CompleteOrderEndpoint
{
    public static async Task<Results<Ok, Conflict>> Handle(
        [AsParameters] Request req,
        [FromServices] OrderRepository repository,
        [FromServices] ILogger<CompleteOrderEndpoint> logger)
    {
        var order = await repository.FindAsync(req.Id);

        try
        {
            order.Complete();
        }
        catch (IncompleteOrderException e)
        {
            logger.LogError(e, "Something bad happened :(");
            return TypedResults.Conflict();
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
    }
}