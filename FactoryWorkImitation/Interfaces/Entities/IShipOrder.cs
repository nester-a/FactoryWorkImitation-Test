using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IShipOrder
    {
        IManager Client { get; }
        ITruckOrder TruckOrder { get; }
        IWorkStatus WorkStatus { get; set; }
    }
}
