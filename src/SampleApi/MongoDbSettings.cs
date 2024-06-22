namespace SampleApi;

internal sealed record MongoDbSettings
{
    public required string ConnectionString { get; init; }
    public required string DatabaseName { get; init; }
}