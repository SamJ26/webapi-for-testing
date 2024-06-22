namespace SampleApi.Domain;

internal sealed class OrderEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Address? DeliveryAddress { get; private set; }
    public Guid? PaymentId { get; private set; }
    public OrderStatus Status { get; private set; }

    public void UpdateDeliveryAddress(
        string country,
        string city,
        string street)
    {
        ValidateStatus(OrderStatus.InProgress);

        DeliveryAddress = new Address()
        {
            Country = country,
            City = city,
            Street = street
        };
    }

    public void Complete()
    {
        ValidateStatus(OrderStatus.InProgress);

        if (DeliveryAddress is null)
        {
            throw new Exception("Delivery address is missing!");
        }

        Status = OrderStatus.Completed;
    }

    public void Pay(Guid paymentId)
    {
        ValidateStatus(OrderStatus.Completed);

        PaymentId = paymentId;
        Status = OrderStatus.Paid;
    }

    private void ValidateStatus(OrderStatus requiredStatus)
    {
        if (Status != requiredStatus)
        {
            throw new Exception($"Operation is not supported for the order in status {Status}!");
        }
    }
}