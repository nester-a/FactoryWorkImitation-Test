namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IShipCompany
    {
        List<ITruck> Trucks { get; }
        bool PlaceShipOrder(IShipOrder order);
        void ParkTheTruck(ITruck truck);
    }
}
