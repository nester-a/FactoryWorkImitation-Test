using FactoryWorkImitation.Common.Entities.Props;
using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables.Base;
using FactoryWorkImitation.Interfaces.Entities.Managers;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Entities.Managers
{
    public class TruckManager : ITruckManager
    {
        Queue<IDeliveryOrder> _orders = new();
        Queue<ITruck> _trucks = new();
        public IManageStrategy ManageStrategy { get; set; } = null!;

        public void Manage()
        {
            Console.WriteLine("Логист начал работу");
            if (!_trucks.Any()) return;
            var truck = _trucks.Dequeue();
            var order = _orders.Dequeue();
            var strategy = ManageStrategy as ITruckStrategy;
            strategy!.Truck = truck;
            strategy.Do(order.FromWhere, order.ToWhere);
        }

        public void DeliveryOrder(IManageable fromWhere, IManageable toWhere)
        {
            var order = new DeliveryOrder(fromWhere, toWhere);
            _orders.Enqueue(order);
            Console.WriteLine("Логист принял заказ на перевозку");
        }

        public void PutInTheGarage(ITruck truck)
        {
            _trucks.Enqueue(truck);
        }
    }
}
