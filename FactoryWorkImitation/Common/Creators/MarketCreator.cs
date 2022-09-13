using FactoryWorkImitation.Common.Entities.Manageables;
using FactoryWorkImitation.Interfaces.Creators;
using FactoryWorkImitation.Interfaces.Entities.Manageables;

namespace FactoryWorkImitation.Common.Creators
{
    public class MarketCreator : IMarketCreator
    {
        public IMarket CreateMarket()
        {
            return new Market();
        }
    }
}
