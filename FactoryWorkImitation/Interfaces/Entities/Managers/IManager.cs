using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Interfaces.Entities.Managers
{
    public interface IManager
    {
        IManageStrategy ManageStrategy { get; }
        void Manage();
    }
}
