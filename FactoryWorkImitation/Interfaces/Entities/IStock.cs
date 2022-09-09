namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IStock
    {
        event EventHandler StockLoadPercent95;

        ITruck? Truck { get; set; }
        int Capacity { get; }
        int FactLoad { get; }
        int FactLoadPercent { get; }
        bool IsFull { get; }
        IManager Manager { get; set; }

        bool PutOnStock(IProduct product);
        IProduct RemoveFromStock();
    }
}
