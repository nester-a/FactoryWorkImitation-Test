using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables.Base;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Entities.Props
{
    public class UnloadTruckStrategy : IManageStrategy
    {
        IManageStrategy _syncManageStrategy = new SyncManageStrategy();
        public void Do(IManageable unloadingObject, IManageable loadingObject)
        {
            if (unloadingObject is not ITruck) return;
            var truck = unloadingObject as ITruck;
            truck!.Drive();
            _syncManageStrategy.Do(truck, loadingObject);
        }
    }
}
