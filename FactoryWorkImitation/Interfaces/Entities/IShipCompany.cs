namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IShipCompany
    {
        ITruck? Truck { get; set; }
        IManager Client { get; set; }
        void SendTruckTo(IStock stock);
    }
}
