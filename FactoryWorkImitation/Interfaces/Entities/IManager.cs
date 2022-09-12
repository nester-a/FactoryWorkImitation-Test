using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IManager
    {
        IManageStrategy ManageStrategy { get; }
        void Manage();
    }
}
