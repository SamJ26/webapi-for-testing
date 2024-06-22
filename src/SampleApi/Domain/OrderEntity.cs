namespace SampleApi.Domain;

internal sealed class OrderEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Address? DeliveryAddress { get; init; }
    public string? PaymentId { get; private set; }
    public OrderStatus Status { get; private set; }
}