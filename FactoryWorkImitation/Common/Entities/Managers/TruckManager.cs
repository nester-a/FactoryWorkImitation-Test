using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Managers;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Entities.Managers
{
    public class TruckManager : IManager
    {
        List<ITruck> Trucks { get; set; }
        public IManageStrategy ManageStrategy { get; set; }

        public void Manage()
        {
            throw new NotImplementedException();
        }
    }
}
