using FactoryWorkImitation.Common.Entities.Props;
using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Entities
{
    public class ShipOrder : IShipOrder
    {
        public IManager Client { get; }

        public ITruckOrder TruckOrder { get; }
        public IWorkStatus WorkStatus { get; set; } = new WorkStoppedStatus();

        public ShipOrder(IManager client, ITruckOrder truckOrder)
        {
            Client = client;
            TruckOrder = truckOrder;
        }
    }
}
