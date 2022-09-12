using FactoryWorkImitation.Interfaces.Entities.Manageables;

namespace FactoryWorkImitation.Interfaces.Entities.Props
{
    public interface IManageStrategy
    {
        void Do(IManageable unloadingObject, IManageable loadingObject);
    }
}
