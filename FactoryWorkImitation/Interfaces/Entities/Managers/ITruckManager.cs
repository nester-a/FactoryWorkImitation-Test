using FactoryWorkImitation.Interfaces.Entities.Manageables.Base;

namespace FactoryWorkImitation.Interfaces.Entities.Managers
{
    public interface ITruckManager : IManager
    {
        void DeliveryOrder(IManageable fromWhere, IManageable toWhere);
    }
}
