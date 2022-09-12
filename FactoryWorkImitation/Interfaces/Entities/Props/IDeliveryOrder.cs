using FactoryWorkImitation.Interfaces.Entities.Manageables.Base;

namespace FactoryWorkImitation.Interfaces.Entities.Props
{
    public interface IDeliveryOrder
    {
        IManageable FromWhere { get; }
        IManageable ToWhere { get; }
    }
}
