using FactoryWorkImitation.Interfaces.Entities.Manageables.Base;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Entities.Props
{
    public class DeliveryOrder : IDeliveryOrder
    {
        public IManageable FromWhere { get; }

        public IManageable ToWhere { get; }

        public DeliveryOrder(IManageable fromWhere, IManageable toWhere)
        {
            FromWhere = fromWhere;
            ToWhere = toWhere;
        }
    }
}
