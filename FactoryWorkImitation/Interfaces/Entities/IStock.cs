namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IStock
    {
        int Capacity { get; }
        int FactLoad { get; }
        int FactLoadPercent { get; }
        bool IsFull { get; }

        bool PutOnStock(IProduct product);
        IProduct RemoveFromStock();
    }
}
