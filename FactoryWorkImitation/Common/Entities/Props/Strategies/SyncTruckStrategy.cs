using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables.Base;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Entities.Props.Strategies
{
    public class SyncTruckStrategy : ITruckStrategy
    {
        IManageStrategy _loadTruckStrategy = new SyncManageStrategy();
        IManageStrategy _unloadTruckStrategy = new SyncManageStrategy();

        public ITruck Truck { get; set; } = null!;

        public void Do(IManageable unloadingObject, IManageable loadingObject)
        {
            Truck.Drive(unloadingObject);
            _loadTruckStrategy.Do(unloadingObject, Truck);
            Truck.Drive(loadingObject);
            _unloadTruckStrategy.Do(Truck, loadingObject);
            Truck.DriveHome();
        }
    }
}
