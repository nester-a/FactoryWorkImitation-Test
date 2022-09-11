using FactoryWorkImitation.Common.Entities.Props;
using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities
{
    public class ShipCompany : IShipCompany
    {
        Queue<ITruck> _trucksWorkQueue = new();
        public List<ITruck> Trucks { get; }
        Queue<IShipOrder> _shipOrders { get; } = new();


        public ShipCompany(List<ITruck> trucks)
        {
            Trucks = trucks;
            foreach (var truck in Trucks)
            {
                truck.Home = this;
                _trucksWorkQueue.Enqueue(truck);
            }
        }
        public bool PlaceShipOrder(IShipOrder order)
        {
            if (!_trucksWorkQueue.Any()) return false;
            order.WorkStatus = new OnWorkStatus();
            _shipOrders.Enqueue(order);
            StartWork();
            return true;
        }

        private void StartWork()
        {   
            var order = _shipOrders.Dequeue();
            var truckOrder = order.TruckOrder;

            var truck = _trucksWorkQueue.Dequeue();

            Task.Factory.StartNew(() => truck.StartWork(truckOrder));
        }


        public void ParkTheTruck(ITruck truck)
        {
            truck.WorkStatus = new WorkStoppedStatus();
            _trucksWorkQueue.Enqueue(truck);
        }
    }
}
