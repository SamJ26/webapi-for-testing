namespace SampleApi.Domain.Exceptions;

internal sealed class IncompleteOrderException : Exception
{
    public IncompleteOrderException(string message) : base(message)
    {
    }
}