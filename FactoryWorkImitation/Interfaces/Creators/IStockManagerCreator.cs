using FactoryWorkImitation.Interfaces.Entities.Managers;

namespace FactoryWorkImitation.Interfaces.Creators
{
    public interface IStockManagerCreator
    {
        IStockManager CreateStockManager();
    }
}
