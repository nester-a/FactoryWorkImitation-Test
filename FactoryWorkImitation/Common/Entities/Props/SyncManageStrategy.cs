using FactoryWorkImitation.Interfaces.Entities.Manageables;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Entities.Props
{
    public class SyncManageStrategy : IManageStrategy
    {
        public void Do(IManageable unloadingObject, IManageable loadingObject)
        {
            while(unloadingObject.IsEmpty || loadingObject.IsFull)
            {
                var product = unloadingObject.Unload();
                var loadRes = loadingObject.Load(product);
                if (!loadRes)
                {
                    unloadingObject.Load(product);
                    break;
                }
            }
        }
    }
}
