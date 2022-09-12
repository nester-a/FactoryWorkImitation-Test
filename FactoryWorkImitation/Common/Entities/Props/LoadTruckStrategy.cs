using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Entities.Props
{
    public class LoadTruckStrategy : IManageStrategy
    {
        IManageStrategy _syncManageStrategy = new SyncManageStrategy();
        public void Do(IManageable unloadingObject, IManageable loadingObject)
        {
            if (loadingObject is not ITruck) return;
            var truck = loadingObject as ITruck;
            truck!.Drive();
            _syncManageStrategy.Do(unloadingObject, truck);
        }
    }
}
