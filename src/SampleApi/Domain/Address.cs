namespace SampleApi.Domain;

internal sealed class Address
{
    public required string Country { get; init; }
    public required string City { get; init; }
    public required string Street { get; init; }
}