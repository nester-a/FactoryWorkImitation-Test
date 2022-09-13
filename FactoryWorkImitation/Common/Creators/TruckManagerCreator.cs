using FactoryWorkImitation.Common.Entities.Managers;
using FactoryWorkImitation.Interfaces.Creators;
using FactoryWorkImitation.Interfaces.Entities.Managers;

namespace FactoryWorkImitation.Common.Creators
{
    public class TruckManagerCreator : ITruckManagerCreator
    {
        public ITruckManager CreateTruckManager()
        {
            return new TruckManager();
        }
    }
}
