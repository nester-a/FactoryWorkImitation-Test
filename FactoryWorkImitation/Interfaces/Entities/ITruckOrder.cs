namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface ITruckOrder
    {
        IStock Stock { get; }
        IMarket Market { get; }
    }
}
