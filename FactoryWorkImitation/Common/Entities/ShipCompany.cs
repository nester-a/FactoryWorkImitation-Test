using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities
{
    public class ShipCompany : IShipCompany
    {
        public ITruck? Truck { get; set; }
        public IManager Client { get; set; }

        public ShipCompany(ITruck truck)
        {
            Truck = truck;
            Truck.Home = this;
            truck.TruckOnStock += Truck_TruckOnStock;
            truck.TruckOnMarket += Truck_TruckOnMarket;
        }

        private void Truck_TruckOnMarket(object? sender, EventArgs e)
        {
            CallAClientStartUnload();
        }

        private void CallAClientStartUnload()
        {
            Client.StartTruckUnloading();
        }
        private void Truck_TruckOnStock(object? sender, EventArgs e)
        {
            CallAClientStartLoading();
        }

        private void CallAClientStartLoading()
        {
            Client.StartTruckLoading();
        }
        public void SendTruckTo(IStock stock)
        {
            if (Truck is not null)
            {
                Truck.MoveTo(stock);
                Truck = null;
            }
            else
                Console.WriteLine("Грузовика нет дома");
        }
    }
}
