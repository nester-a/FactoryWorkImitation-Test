using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables.Base;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Entities.Props.Strategies
{
    public class ConcurrencyTruckStrategy : ITruckStrategy
    {

        ITruckStrategy _truckStrategy = new SyncTruckStrategy();

        public ITruck Truck { get; set; } = null!;

        public void Do(IManageable unloadingObject, IManageable loadingObject)
        {
            _truckStrategy.Truck = Truck;
            Task.Factory.StartNew(() =>
            {
                _truckStrategy.Do(unloadingObject, loadingObject);

            });
        }
    }
}
