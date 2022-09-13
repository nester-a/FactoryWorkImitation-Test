using FactoryWorkImitation.Interfaces.Entities.Manageables.Base;

namespace FactoryWorkImitation.Interfaces.Entities.Props
{
    public interface IManageStrategy
    {
        void Do(IManageable unloadingObject, IManageable loadingObject);
    }
}
