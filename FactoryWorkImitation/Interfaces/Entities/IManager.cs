namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IManager
    {
        IStock Stock { get; }
        IMarket Market { get; }
        IShipCompany ShipCompany { get; }
        void CallATruck();
        void StartTruckLoading();
        void StartTruckUnloading();

        void ManageWork();
    }
}
