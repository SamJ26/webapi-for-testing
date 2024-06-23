namespace SampleApi.Domain.Exceptions;

internal sealed class InvalidOrderOperationException : Exception
{
    public InvalidOrderOperationException(string message) : base(message)
    {
    }
}