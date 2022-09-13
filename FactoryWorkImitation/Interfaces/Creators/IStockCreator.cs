using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Interfaces.Creators
{
    public interface IStockCreator
    {
        int SetCapacity { get; set; }
        IStock CreateStock();
    }
}
