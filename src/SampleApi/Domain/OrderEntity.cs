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
        if (Status != OrderStatus.InProgress)
        {
            throw new Exception("Unable to set delivery address!");
        }

        DeliveryAddress = new Address()
        {
            Country = country,
            City = city,
            Street = street
        };
    }

    public void Pay(Guid paymentId)
    {
        if (Status != OrderStatus.Completed)
        {
            throw new Exception("Unable to set payment id!");
        }

        PaymentId = paymentId;
        Status = OrderStatus.Paid;
    }

    public void Complete()
    {
        Status = OrderStatus.Completed;
    }
}