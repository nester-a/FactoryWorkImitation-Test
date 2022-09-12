using FactoryWorkImitation.Interfaces.Entities.Manageables;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Entities.Props
{
    public class ConcurrencyManageStratery : IManageStrategy
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
