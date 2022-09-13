using FactoryWorkImitation.Interfaces.Entities.Manageables.Base;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Entities.Props.Strategies
{
    public class ConcurrencyManageStrategy : IManageStrategy
    {
        IManageStrategy _syncManageStrategy = new SyncManageStrategy();
        public void Do(IManageable unloadingObject, IManageable loadingObject)
        {
            Task.Factory.StartNew(() =>
            {
                _syncManageStrategy.Do(unloadingObject, loadingObject);
            });
        }
    }
}
