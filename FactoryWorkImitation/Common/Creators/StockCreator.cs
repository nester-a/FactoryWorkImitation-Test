using FactoryWorkImitation.Common.Entities.Manageables;
using FactoryWorkImitation.Interfaces.Creators;
using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Creators
{
    public class StockCreator : IStockCreator
    {
        int StocksCount { get; set; }

        int _capacity;
        public int SetCapacity
        {
            get { return _capacity; }
            set
            {
                if (value < 0) _capacity = 100;
                else _capacity = value;
            }
        }

        public IStock CreateStock()
        {
            StocksCount++;
            return new Stock($"Склад-{StocksCount}", _capacity);
        }
    }
}
