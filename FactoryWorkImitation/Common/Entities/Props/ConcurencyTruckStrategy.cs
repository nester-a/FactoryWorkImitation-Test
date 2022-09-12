using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables.Base;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Entities.Props
{
    public class ConcurencyTruckStrategy : ITruckStrategy
    {

        IManageStrategy _loadTruckStrategy = new LoadTruckStrategy();
        IManageStrategy _unloadTruckStrategy = new UnloadTruckStrategy();

        public ITruck Truck { get; set; }

        public void Do(IManageable unloadingObject, IManageable loadingObject)
        {
            Task.Factory.StartNew(() =>
            {
                _loadTruckStrategy.Do(unloadingObject, Truck);
                _unloadTruckStrategy.Do(Truck, loadingObject);

            });
        }
    }
}
