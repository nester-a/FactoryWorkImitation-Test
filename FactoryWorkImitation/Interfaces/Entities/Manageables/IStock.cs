using FactoryWorkImitation.Interfaces.Entities.Manageables.Base;

namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IStock : IManageable
    {
        event EventHandler StockIsAlmostFull;
        int Capacity { get; }
        int FactLoad { get; }
    }
}
