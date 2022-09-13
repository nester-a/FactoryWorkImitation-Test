using FactoryWorkImitation.Common.Entities.Managers;
using FactoryWorkImitation.Interfaces.Creators;
using FactoryWorkImitation.Interfaces.Entities.Managers;

namespace FactoryWorkImitation.Common.Creators
{
    public class StockManagerCreator : IStockManagerCreator
    {
        public IStockManager CreateStockManager()
        {
            return new StockManager();
        }
    }
}
