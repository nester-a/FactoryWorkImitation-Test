namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IStock
    {
        event EventHandler StockLoadPercent95;

        int Capacity { get; }
        int FactLoad { get; }
        int FactLoadPercent { get; }
        bool IsFull { get; }

        bool PutOnStock(IProduct product);
        IProduct RemoveFromStock();
    }
}
