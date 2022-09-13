using FactoryWorkImitation.Interfaces.Entities.Manageables.Base;

namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IStock : IManageable, IStatisticsHandler
    {
        event EventHandler StockIsAlmostFull;
        int Capacity { get; }
        int FactLoad { get; }
    }
}
