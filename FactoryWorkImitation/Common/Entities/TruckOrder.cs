using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities
{
    public class TruckOrder : ITruckOrder
    {
        public IStock Stock { get; }

        public IMarket Market { get; }

        public TruckOrder(IStock stock, IMarket market)
        {
            Stock = stock;
            Market = market;
        }
    }
}
