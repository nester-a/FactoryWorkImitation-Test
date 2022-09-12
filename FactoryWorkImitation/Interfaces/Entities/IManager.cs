using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IManager
    {
        List<IManageable> ManageableObjects { get; set; }
        IManageStrategy ManageStrategy { get; }
        void Manage();
    }
}
