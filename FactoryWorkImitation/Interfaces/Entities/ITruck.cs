namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface ITruck
    {
        Stack<IProduct> Products { get; }
        event EventHandler? TruckOnStock;
        event EventHandler? TruckOnMarket;
        IShipCompany Home { get; set; }
        int Capacity { get; }
        int FactLoad { get; }
        bool IsFull { get; }
        void MoveTo(IStock stock);
        void MoveTo(IMarket market);
        void MoveHome();
        bool PickUp(IProduct product);
        IProduct UnloadProduct();
    }
}
